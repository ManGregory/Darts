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
            UpdateGameState();
            AddGrids();
        }

        private void AddGrids()
        {
            if (_rule.IsCommand)
            {
                var gridCount = _members.Count;
                for (var memberIndex = 0; memberIndex < _members.Count; memberIndex++)
                {
                    var member = (_members[memberIndex] as Team);
                    pnlPlayers.Controls.Add(CreateNewTeamGrid(member, gridCount, memberIndex));
                }
            }
            else
            {
                pnlPlayers.Controls.Add(CreateNewUserGird());
            }
        }

        private static RadGridView CreateNewUserGird()
        {
            var grid = new RadGridView
            {
                Name = "gridPlayers",
                Dock = DockStyle.Fill
            };
            return grid;
        }

        private RadGridView CreateNewTeamGrid(Team member, int gridCount, int gridNum)
        {
            var grid = new RadGridView
            {
                Name = "grid" + member.Name,
                Width = GetGridWidth(gridCount),
                Left = GetGridWidth(gridCount) * gridNum + 1,
                Height = GetGridHeight()
            };
            return grid;
        }

        private int GetGridHeight()
        {
            return pnlPlayers.Height;
        }

        private int GetGridWidth(int gridCount)
        {
            return pnlPlayers.ClientRectangle.Width/gridCount;
        }

        private void UpdateGameState()
        {
            lblCurrentPlayer.Text = _gameFlow.CurrentPlayer;
            lblSerieNum.Text = _gameFlow.CurrentSerieNum.ToString();
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
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(Control).IsAssignableFrom(field.FieldType)
                   let component = (Control)field.GetValue(this)
                   where component != null
                   select component;
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
                    throwLabelSum.Text = (throwEdit.Value*throwFactor.Value).ToString();
                }
            }
            lblSumSerie.Text = GetSerieSum().ToString();
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
            SaveSerieToDb(serie);
            AddSerie(_gameFlow.CurrentUser, serie);
            InitThrow();
            _gameFlow.MoveNextPlayer();
            UpdateGameState();
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
