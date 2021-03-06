﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DartsBoard.Controls.DartsBoard;
using DartsConsole;
using DartsLogic;
using Telerik.WinControls.UI;
using Rule = DartsConsole.Rule;

namespace DartsWin
{
    public partial class GameForm : RadForm
    {
        private readonly Db _connectionDb;
        private readonly Rule _rule;
        private readonly GameHeader _gameHeader;
        private readonly List<Team> _teams = new List<Team>();
        private readonly GameFlow _gameFlow;
        private readonly GameChecker _gameChecker;
        private readonly Dictionary<User, List<DartsSerie>> _userSeries = new Dictionary<User, List<DartsSerie>>();  

        // todo delete member class
        public GameForm(Db connectionDb, Rule rule, IEnumerable<Team> members, GameHeader gameHeader)
        {
            InitializeComponent();
            _connectionDb = connectionDb;
            _gameHeader = gameHeader;
            _rule = rule;
            _connectionDb.ConnectionContext.Teams.Load();
            _teams.AddRange(members);
            Text = GetFormText();
            _gameChecker = GameCheckerFactory.GetGameChecker(_rule);
            _gameFlow = new GameFlow(_rule, _teams);
            InitThrow();
            AddGrids();
            UpdateGameState();
            LoadExistingGame();
        }

        private void LoadExistingGame()
        {
            var gameLineRows = 
                _connectionDb.ConnectionContext.GameLines.Where(gl => gl.GameHeaderId == _gameHeader.Id).ToList();
            if (gameLineRows.Count > 0)
            {
                var rowIndex = 0;
                var prevRow = gameLineRows[rowIndex];
                while (rowIndex < gameLineRows.Count)
                {
                    if (prevRow.User.Id != gameLineRows[rowIndex].User.Id)
                    {
                        btnNext_Click(prevRow, null);
                        prevRow = gameLineRows[rowIndex];
                    }
                    SetScore(gameLineRows[rowIndex].Factor, 
                        new DartbordEventArgs(
                            gameLineRows[rowIndex].Sector * gameLineRows[rowIndex].Factor,
                            "", 
                            gameLineRows[rowIndex].ThrowNum)); 
                    rowIndex++;
                }
                btnNext_Click(gameLineRows[rowIndex - 1], null);
            }
        }

        private void AddGrids()
        {
            var gridCount = _teams.Count;
            for (var memberIndex = 0; memberIndex < _teams.Count; memberIndex++)
            {
                var team = _teams[memberIndex];
                pnlPlayers.Controls.Add(CreateTeamGridPanel(team, gridCount, memberIndex));
            }
        }

        private GridPlayerPanel CreateTeamGridPanel(Team member, int gridCount, int gridNum)
        {
            var gridPanel = new GridPlayerPanel
            {
                Name = GetGridPanelName(member),
                Tag = member,
                Width = GetGridPanelWidth(gridCount),
                Left = GetGridPanelWidth(gridCount)*gridNum + 1,
                Height = GetGridPanelHeight()
            };
            gridPanel.NamePanel.Text = member.Name;
            foreach (var user in member.UsersAttending)
            {
                gridPanel.TeamGrid.Columns.Add(CreateGridColumn(user));
            }
            return gridPanel;
        }

        private static GridViewTextBoxColumn CreateGridColumn(User user)
        {
            return new GridViewTextBoxColumn
            {
                Name = user.Id.ToString(CultureInfo.InvariantCulture),
                HeaderText = user.Name
            };
        }

        private string GetGridPanelName(Team member)
        {
            return "gridPanel" + member.Id;
        }

        private int GetGridPanelHeight()
        {
            return pnlPlayers.Height;
        }

        private int GetGridPanelWidth(int gridCount)
        {
            return pnlPlayers.ClientRectangle.Width/gridCount;
        }

        private void UpdateGameState()
        {
            lblCurrentPlayer.Text = _gameFlow.CurrentPlayer;
            lblSerieNum.Text = GetSerieStatusText();
            UpdateStatusPanels();
            UpdatePossibleCombinations();
            ctlDartbord1.ResetThrows();
        }

        private string GetSerieStatusText()
        {
            var addMessage = "";
            var sum = GetTeamSum(_gameFlow.CurrentTeam);
            if (_gameChecker.IsGameFinished(sum, GetCurrentSerie()))
            {
                addMessage = string.Format(", победитель - {0}", _gameFlow.CurrentTeam.Name);
            }
            if (_gameChecker.IsGameBusted(sum, GetCurrentSerie()))
            {
                addMessage = string.Format(", перебор - {0}", _gameFlow.CurrentTeam.Name);
            }
            return string.Format("Ход - {0}" + addMessage, _gameFlow.CurrentSerieNum);
        }

        private void UpdateStatusPanels()
        {
            foreach (GridPlayerPanel gridPanel in EnumerateControls().Where(c => c.GetType() == typeof (GridPlayerPanel)))
            {
                gridPanel.StatusPanel.Text = GetGameStatus(gridPanel.Tag);
            }
        }

        private string GetGameStatus(object gridTag)
        {
            var team = gridTag as Team;
            return GetTeamStatusText(team);
        }

        private string GetTeamStatusText(Team team)
        {
            var sum = GetTeamSum(team);
            var limit = GetGameLimit();
            return string.Format("<html>Сумма - {0}<br>Остаток - {1}</html>", sum, (limit - sum));
        }

        private int GetTeamSum(Team team)
        {
            return team.UsersAttending.Sum(user => GetUserSum(user));
        }

        private int GetGameLimit()
        {
            if (_rule.Name == "501")
            {
                return 501;
            }
            return _rule.Name == "301" ? 301 : 0;
        }

        private int GetUserSum(User user)
        {
            return _userSeries.ContainsKey(user) ? _userSeries[user].Sum(s => s.GetSum()) : 0;
        }

        private void InitThrow()
        {
            edThrow1.Value = edThrow2.Value = edThrow3.Value = 0;
            edFactor1.Value = edFactor2.Value = edFactor3.Value = 0;
            lblSumSerie.Text = lblSumThrow1.Text = lblSumThrow2.Text = lblSumThrow3.Text = @"0";
        }

        private IEnumerable<Control> EnumerateControls()
        {
            return EnumerateControls(this);
        }

        private IEnumerable<Control> EnumerateControls(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(EnumerateControls)
                .Concat(controls);
        }

        private void ThrowEditValueChanged(object sender, EventArgs eventArgs)
        {
            var edit = (sender as NumericUpDown);
            if (edit != null)
            {
                var lastNum = edit.Name.Substring(edit.Name.Length - 1);
                var throwLabelSum = EnumerateControls().Single(e => e.Name == "lblSumThrow" + lastNum) as RadLabel;
                var throwEdit = EnumerateControls().Single(e => e.Name == "edThrow" + lastNum) as NumericUpDown;
                var throwFactor = EnumerateControls().Single(e => e.Name == "edFactor" + lastNum) as NumericUpDown;
                if (throwLabelSum != null && throwEdit != null && throwFactor != null)
                {
                    if (IsValidThrowValue(throwEdit))
                    {
                        throwLabelSum.Text = (throwEdit.Value * throwFactor.Value).ToString(CultureInfo.InvariantCulture);
                        UpdateDynamicStatusPanel();
                        UpdatePossibleCombinations();
                        lblSerieNum.Text = GetSerieStatusText();
                    }
                    else
                    {
                        throwEdit.Value = 0;
                    }
                }
            }
            lblSumSerie.Text = GetSerieSum().ToString(CultureInfo.InvariantCulture);
        }

        private void UpdatePossibleCombinations()
        {
            var sum = GetTeamSum(_gameFlow.CurrentTeam) + GetCurrentSerie().GetSum();
            var limit = GetGameLimit();
            var series = DartsEnding.GetPossibleEndings(limit - sum);
            lblPossibleCombinations.Text = string.Join("; ", series.Select(s => s.ToString(true)));             
        }

        private void UpdateDynamicStatusPanel()
        {
            var gridPanel =
                EnumerateControls().Single(c => c.Name == GetGridPanelName(_gameFlow.CurrentTeam)) as
                    GridPlayerPanel;
            if (gridPanel != null) gridPanel.StatusPanel.Text = GetTeamDynamicStatusText(_gameFlow.CurrentTeam);
        }

        private string GetTeamDynamicStatusText(Team team)
        {
            var sum = GetTeamSum(team) + GetCurrentSerie().GetSum();
            var limit = GetGameLimit();
            return string.Format("<html>Сумма - {0}<br>Остаток - {1}</html>", sum, (limit - sum));            
        }

        private static bool IsValidThrowValue(NumericUpDown throwEdit)
        {
            return (throwEdit.Value >= 0 && throwEdit.Value <= 20) || (throwEdit.Value == 25);
        }

        private decimal GetSerieSum()
        {
            return
                (edThrow1.Value*edFactor1.Value) +
                (edThrow2.Value*edFactor2.Value) +
                (edThrow3.Value*edFactor3.Value);
        }

        private string GetFormText()
        {
            return _rule.IsCommand
                ? string.Format("Командная игра - {0}", _rule.Name)
                : string.Format("Игра - {0}", _rule.Name);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var gameLineRow = sender as GameLine;
            var isGameBusted = _gameChecker.IsGameBusted(GetTeamSum(_gameFlow.CurrentTeam), GetCurrentSerie()) || ((gameLineRow != null) && (gameLineRow.IsBust));
            var isGameFinished = _gameChecker.IsGameFinished(GetTeamSum(_gameFlow.CurrentTeam), GetCurrentSerie());

            var serie = isGameBusted ? GetZeroSerie() : GetCurrentSerie();
            if (gameLineRow == null) SaveSerieToDb(serie);
            AddSerie(_gameFlow.CurrentUser, serie);
            AddGridRow(serie);
            if (isGameFinished)
            {
                SwitchGui(false);
                if (gameLineRow == null) SaveGameEnd();
                return;
            }
            InitThrow();
            if (isGameBusted)
            {
                _gameFlow.MoveNextTeam();                     
            }
            else
            {
                _gameFlow.MoveNextPlayer();
            }
            UpdateGameState();
        }

        private void SaveGameEnd()
        {
            _gameHeader.EndTimestamp = DateTime.Now;
            _gameHeader.TeamWinner = _gameFlow.CurrentTeam;
            _connectionDb.ConnectionContext.SaveChanges();
        }

        private void SwitchGui(bool enabled)
        {
            grpCurrentThrow.Enabled = enabled;
            ctlDartbord1.Enabled = enabled;
        }

        private DartsSerie GetZeroSerie()
        {
            return new DartsSerie(new []
            {
                new DartsThrow(1, new DartsScore(0, 0, true)),
                new DartsThrow(2, new DartsScore(0, 0, true)),
                new DartsThrow(3, new DartsScore(0, 0, true))
            });
        }

        private void AddGridRow(DartsSerie serie)
        {
            var grid = GetCurrentGrid();
            if (grid != null)
            {
                if (grid.Rows.Count < _gameFlow.CurrentSerieNum)
                {
                    var row = grid.Rows.AddNew();
                    row.Cells[_gameFlow.CurrentUser.Id.ToString(CultureInfo.InvariantCulture)].Value = serie.GetSum();
                }
                else
                {
                    grid.Rows[_gameFlow.CurrentSerieNum - 1].Cells[_gameFlow.CurrentUser.Id.ToString(CultureInfo.InvariantCulture)].Value =
                        serie.GetSum();
                }             
            }
        }

        private RadGridView GetCurrentGrid()
        {
            var gridPlayerPanel =
                EnumerateControls().Single(c => c.Name == GetGridPanelName(_gameFlow.CurrentTeam)) as GridPlayerPanel;
            if (gridPlayerPanel != null)
                return gridPlayerPanel.TeamGrid;
            return null;
        }

        private void AddSerie(User user, DartsSerie serie)
        {
            if (_userSeries.ContainsKey(user))
            {
                if (_userSeries[user] == null)
                {
                    _userSeries[user] = new List<DartsSerie>();
                }
                _userSeries[user].Add(serie);
            }
            else
            {
                _userSeries.Add(user, new List<DartsSerie>(new[] {serie}));
            }
        }

        private void SaveSerieToDb(DartsSerie serie)
        {
            try
            {
                foreach (var t in serie.Throws)
                {
                    _connectionDb.ConnectionContext.GameLines.Add(
                        new GameLine
                        {
                            GameHeader = _gameHeader,
                            Factor = t.Score.Factor,
                            Sector = t.Score.Sector,
                            ThrowNum = t.Number,
                            IsBust = t.Score.IsBust,
                            Team = _gameFlow.CurrentTeam,
                            User = _gameFlow.CurrentUser                            
                        }
                        );
                }
                _connectionDb.ConnectionContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DartsSerie GetCurrentSerie()
        {
            return new DartsSerie(GetThrows());
        }

        private IEnumerable<DartsThrow> GetThrows()
        {
            var result = new List<DartsThrow>();
            result.AddRange(new []
            {
                GetThrow(1), 
                GetThrow(2),
                GetThrow(3)
            });
            return result;
        }

        private DartsThrow GetThrow(int num)
        {
            return new DartsThrow(num, GetScore(num));
        }

        private DartsScore GetScore(int num)
        {
            return new DartsScore
            {
                Factor =
                    (int)(EnumerateControls().Single(c => c.Name == "edFactor" + num.ToString(CultureInfo.InvariantCulture)) as NumericUpDown).Value,
                Sector =
                    (int)(EnumerateControls().Single(c => c.Name == "edThrow" + num.ToString(CultureInfo.InvariantCulture)) as NumericUpDown).Value,
            };
        }

        private void ctlDartbord1_SingleThrown(object sender, DartbordEventArgs e)
        {
            SetScore(1, e);
        }

        private void SetScore(int factor, DartbordEventArgs e)
        {
            var edFactor =
                (EnumerateControls().Single(c => c.Name == "edFactor" + e.Throw.ToString(CultureInfo.InvariantCulture)) as
                    NumericUpDown);
            var edThrow =
                (EnumerateControls().Single(c => c.Name == "edThrow" + e.Throw.ToString(CultureInfo.InvariantCulture)) as
                    NumericUpDown);
            if (edFactor != null) edFactor.Value = factor;
            if (edThrow != null)
            {
                if (factor == 0)
                {
                    edThrow.Value = 0;
                }
                else
                {
                    // ReSharper disable once PossibleLossOfFraction
                    edThrow.Value = e.Score/factor;
                }
            }
        }

        private void ctlDartbord1_DoubleThrown(object sender, DartbordEventArgs e)
        {
            SetScore(2, e);
        }

        private void ctlDartbord1_NoScoreThrown(object sender, DartbordEventArgs e)
        {
            SetScore(1, e);
        }

        private void ctlDartbord1_TripleThrown(object sender, DartbordEventArgs e)
        {
            SetScore(3, e);
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // если не все команды бросили хотя бы по одному разу
            // загрузка игры будет невозможна, поэтому надо предупредить пользователя
            // и удалить если потребуется заголовок
            if (_gameFlow.CurrentSerieNum <= 1)
            {
                if (MessageBox.Show("", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _connectionDb.ConnectionContext.GameHeaders.Remove(_gameHeader);
                    _connectionDb.ConnectionContext.SaveChanges();
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
