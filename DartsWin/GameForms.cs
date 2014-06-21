using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DartsConsole;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace DartsWin
{
    public partial class GameForm : Telerik.WinControls.UI.RadForm
    {
        private Db _connectionDb;
        private DartsConsole.Rule _rule;
        private GameHeader _gameHeader;
        private List<object> _members = new List<object>();
        private GameFlow _gameFlow;
        private Dictionary<User, List<DartsSerie>> _userSeries = new Dictionary<User, List<DartsSerie>>();  

        public GameForm(Db connectionDb, DartsConsole.Rule rule, List<Member> members, GameHeader gameHeader)
        {
            // todo add dartboard control
            InitializeComponent();
            _connectionDb = connectionDb;
            _gameHeader = gameHeader;
            _rule = rule;
            if (rule.IsCommand)
            {
                _connectionDb.ConnectionContext.Teams.Load();
                _members.AddRange(_connectionDb.ConnectionContext.Teams.Local.ToList()
                    .Where(m => members.Exists(m1 => m1.Id == m.Id)));
            }
            else
            {
                _connectionDb.ConnectionContext.Users.Load();
                _members.AddRange(_connectionDb.ConnectionContext.Users.Local.ToBindingList()
                    .Where(m => members.Exists(m1 => m1.Id == m.Id)));
            }
            Text = GetFormText();
            txtRuleDescription.Text = _rule.Description;
            txtRuleDescription.IsReadOnly = true;
            txtRuleDescription.DeselectAll();

            _gameFlow = new GameFlow(_rule, _members);
            InitThrow();
            AddGrids();
            UpdateGameState();
        }

        private void AddGrids()
        {
            if (_rule.IsCommand)
            {
                var gridCount = _members.Count;
                for (var memberIndex = 0; memberIndex < _members.Count; memberIndex++)
                {
                    var member = (_members[memberIndex] as Team);
                    pnlPlayers.Controls.Add(CreateTeamGridPanel(member, gridCount, memberIndex));
                }
            }
            else
            {
                pnlPlayers.Controls.Add(CreateUserGridPanel(_members.Cast<User>()));
            }
        }

        private static GridPlayerPanel CreateUserGridPanel(IEnumerable<User> players)
        {
            var gridPanel = new GridPlayerPanel
            {
                Name = "gridPlayers",
                Dock = DockStyle.Fill
            };
            gridPanel.NamePanel.Visible = false;
            foreach (var player in players)
            {
                gridPanel.TeamGrid.Columns.Add(CreateGridColumn(player));
            }
            return gridPanel;
        }

        private GridPlayerPanel CreateTeamGridPanel(Team member, int gridCount, int gridNum)
        {
            var gridPanel = new GridPlayerPanel()
            {
                Name = GetGridPanelName(member),
                Tag = member,
                Width = GetGridPanelWidth(gridCount),
                Left = GetGridPanelWidth(gridCount)*gridNum + 1,
                Height = GetGridPanelHeight(),
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
                Name = user.Id.ToString(),
                HeaderText = user.Name
            };
        }

        private string GetGridPanelName(Team member)
        {
            return "gridPanel" + member.Id.ToString();
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
            lblSerieNum.Text = _gameFlow.CurrentSerieNum.ToString();
            foreach (GridPlayerPanel gridPanel in EnumerateControls().Where(c => c.GetType() == typeof(GridPlayerPanel)))
            {
                gridPanel.StatusPanel.Text = GetGameStatus(gridPanel.Tag);
            }
        }

        private string GetGameStatus(object gridTag)
        {
            var team = gridTag as Team;
            return _rule.IsCommand ? GetTeamStatusText(team) : GridUserStatusText();
        }

        private string GridUserStatusText()
        {
            return "";
        }

        private string GetTeamStatusText(Team team)
        {
            var sum = GetTeamSum(team);
            var limit = GetGameLimit();
            return string.Format("Сумма - {0}, Остаток - {1}", sum, (limit - sum));
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
            edThrow1.Value = 0;
            edThrow2.Value = 0;
            edThrow3.Value = 0;
            edFactor1.Value = 1;
            edFactor2.Value = 1;
            edFactor3.Value = 1;
            lblSumSerie.Text = "0";
            lblSumThrow1.Text = "0";
            lblSumThrow2.Text = "0";
            lblSumThrow3.Text = "0";
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
                        throwLabelSum.Text = (throwEdit.Value * throwFactor.Value).ToString();   
                    }
                    else
                    {
                        throwEdit.Value = 1;
                    }
                }
            }
            lblSumSerie.Text = GetSerieSum().ToString();
        }

        private static bool IsValidThrowValue(NumericUpDown throwEdit)
        {
            return (throwEdit.Value >= 1 && throwEdit.Value <= 20) || (throwEdit.Value == 25);
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
            var serie = GetCurrentSerie();
            // todo check the bust and end the team serie
            // todo check the game end, save to db
            SaveSerieToDb(serie);            
            AddSerie(_gameFlow.CurrentUser, serie);
            AddGridRow(serie);
            InitThrow();
            _gameFlow.MoveNextPlayer();
            UpdateGameState();
        }

        private void AddGridRow(DartsSerie serie)
        {
            var grid = GetGrid();
            if (grid != null)
            {
                if (grid.Rows.Count < _gameFlow.CurrentSerieNum)
                {
                    var row = grid.Rows.AddNew();
                    row.Cells[_gameFlow.CurrentUser.Id.ToString()].Value = serie.GetSum();
                }
                else
                {
                    grid.Rows[_gameFlow.CurrentSerieNum - 1].Cells[_gameFlow.CurrentUser.Id.ToString()].Value =
                        serie.GetSum();
                }             
            }
        }

        private RadGridView GetGrid()
        {
            return _rule.IsCommand
                ? (EnumerateControls().Single(c => c.Name == GetGridPanelName(_gameFlow.CurrentTeam)) as GridPlayerPanel).TeamGrid
                : (EnumerateControls().Single(c => c.Name == "gridPlayers") as GridPlayerPanel).TeamGrid;
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
                    (int)(EnumerateControls().Single(c => c.Name == "edFactor" + num.ToString()) as NumericUpDown).Value,
                Sector =
                    (int)(EnumerateControls().Single(c => c.Name == "edThrow" + num.ToString()) as NumericUpDown).Value,
            };
        }
    }

    public class GameFlow
    {
        private DartsConsole.Rule _rule;
        private List<object> _players;
        private int _currentTeamIndex;
        private int _currentUserIndex;

        public int CurrentSerieNum { get; private set; }

        public string CurrentPlayer
        {
            get { return GetCurrentPlayerText(); }
        }

        public User CurrentUser
        {
            get { return GetCurrentUser(); }
        }

        public Team CurrentTeam
        {
            get
            {
                return GetCurrentTeam();
            }
        }

        public GameFlow(DartsConsole.Rule rule, IEnumerable<object> players)
        {
            _rule = rule;
            _players = new List<object>(players);
            _currentTeamIndex = 0;
            _currentUserIndex = 0;
            CurrentSerieNum = 1;
        }

        private string GetCurrentPlayerText()
        {
            return _rule.IsCommand
                ? "Команда: " + GetCurrentTeam().Name + ", Игрок: " + GetCurrentUser().Name
                : "Игрок: " + GetCurrentUser().Name;
        }

        private Team GetCurrentTeam()
        {
            return _rule.IsCommand ? (_players[_currentTeamIndex] as Team) : null;
        }

        private User GetCurrentUser()
        {
            return _rule.IsCommand
                ? GetCurrentTeam().UsersAttending.ToList()[_currentUserIndex]
                : (_players[_currentUserIndex] as User);
        }


        public void MoveNextPlayer()
        {
            if (_rule.IsCommand)
            {
                if (_currentUserIndex + 1 >= GetCurrentTeam().UsersAttending.Count)
                {
                    if (_currentTeamIndex + 1 >= _players.Count)
                    {
                        CurrentSerieNum++;
                        _currentTeamIndex = 0;
                        _currentUserIndex = 0;
                    }
                    else
                    {
                        _currentTeamIndex++;
                        _currentUserIndex = 0;
                    }
                }
                else
                {
                    _currentUserIndex++;
                }
            }
            else
            {
                if (_currentUserIndex + 1 >= _players.Count)
                {
                    CurrentSerieNum++;
                    _currentUserIndex = 0;
                }
                else
                {
                    _currentUserIndex++;
                }
            }
        }
    }
}
