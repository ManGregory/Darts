using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using DartsConsole;
using MoreLinq;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace DartsWin
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        private readonly Db _connectionDb;
        private readonly BindingSource _gameBindingSource = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
            var connectionString = Convert.ToBoolean(ConfigurationManager.AppSettings["useRemote"])
                ? ConfigurationManager.ConnectionStrings["DartsRemote"].ConnectionString
                : string.Empty;
            _connectionDb = new Db(connectionString);
            Database.SetInitializer(new CreateDatabaseIfNotExists<DartsContext>());

            LoadGames();
            gridGames.AutoGenerateColumns = true;
            gridGames.AllowAddNewRow = false;
            gridGames.DataSource = _gameBindingSource;
            if (gridGames.Columns.Count == 6)
            {
                gridGames.Columns[0].VisibleInColumnChooser = gridGames.Columns[0].IsVisible = false;
                gridGames.Columns[1].HeaderText = "Начало игры";
                gridGames.Columns[2].HeaderText = "Конец игры";
                gridGames.Columns[3].HeaderText = "Тип игры";
                gridGames.Columns[4].HeaderText = "Командная";
                gridGames.Columns[5].HeaderText = "Победитель";
            }
            gridGames.ShowHeaderCellButtons = true;
            gridGames.ShowFilteringRow = false;
            gridGames.EnableFiltering = true;
            gridGames.FilterPopupRequired += (sender, args) => args.FilterPopup = new RadListFilterPopup(args.Column, true);            
            RadGridLocalizationProvider.CurrentProvider = new RussianRadGridLocalizationProvider();
            gridGames.TableElement.UpdateView();
            gridGames.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;  
        }

        private void LoadGames()
        {
            _connectionDb.ConnectionContext.GameHeaders.Load();
            _gameBindingSource.DataSource = _connectionDb.ConnectionContext.GameHeaders
                .Local.ToBindingList()
                .Select(
                g => new {g.Id, g.BeginTimestamp, g.EndTimestamp, RuleName = g.Rule.Name, 
                    g.Rule.IsCommand, TeamWinnerName = g.TeamWinner != null ? g.TeamWinner.Name : string.Empty})
                .OrderByDescending(g => g.BeginTimestamp);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            using (var usersForm = new UsersForm(_connectionDb))
            {
                usersForm.ShowDialog(this);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {            
            _connectionDb.ConnectionContext.Dispose();
        }

        private void btnTeams_Click(object sender, EventArgs e)
        {
            using (var teamsForm = new TeamsForm(_connectionDb))
            {
                teamsForm.ShowDialog(this);
            }
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            using (var rulesForm = new RulesForm(_connectionDb))
            {
                rulesForm.ShowDialog(this);
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            using (var gameSettingsForm = new GameSettingsForm(_connectionDb))
            {
                gameSettingsForm.ShowDialog(this);
                LoadGames();
            }
        }

        private void gridGames_DoubleClick(object sender, EventArgs e)
        {
            dynamic gameHeaderDynamic = _gameBindingSource.Current;
            int gameId = gameHeaderDynamic.Id;
            var gameHeader = _connectionDb.ConnectionContext.GameHeaders.Single(gh => gh.Id == gameId);
            var members =
                _connectionDb.ConnectionContext.GameLines.Where(gl => gl.GameHeaderId == gameHeader.Id)
                    .DistinctBy(gl => gl.TeamId).Select(gl => gl.Team).ToList();
            using (var gameForm = new GameForm(_connectionDb, gameHeader.Rule, members, gameHeader))
            {
                gameForm.ShowDialog(this);
                LoadGames();
            }
        }
    }
}
