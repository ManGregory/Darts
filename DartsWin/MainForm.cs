using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DartsConsole;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace DartsWin
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        private Db _connectionDb = new Db();
        private BindingSource _gameBindingSource = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
            Database.SetInitializer(new CreateDatabaseIfNotExists<DartsContext>());

            LoadGames();
            gridGames.AutoGenerateColumns = true;
            gridGames.AllowAddNewRow = false;
            gridGames.DataSource = _gameBindingSource;
            if (gridGames.Columns.Count == 4)
            {
                gridGames.Columns[0].HeaderText = "Начало игры";
                gridGames.Columns[1].HeaderText = "Конец игры";
                gridGames.Columns[2].HeaderText = "Тип игры";
                gridGames.Columns[3].HeaderText = "Командная";
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
                    g => new {g.BeginTimestamp, g.EndTimestamp, RuleName = g.Rule.Name, IsCommand = g.Rule.IsCommand})
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
    }
}
