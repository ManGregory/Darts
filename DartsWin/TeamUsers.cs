using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DartsConsole;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace DartsWin
{
    public partial class TeamUsers : Telerik.WinControls.UI.RadForm
    {
        private Db _connectionDb;
        private Team _team;
        private BindingSource _teamUserBindingSource = new BindingSource();
        private BindingSource _userBindingSource = new BindingSource();

        public TeamUsers(Db connectionDb, Team team)
        {
            InitializeComponent();
            _connectionDb = connectionDb;
            _team = team;
            this.Text = string.Format("Игроки команды \"{0}\"", team.Name);
            _teamUserBindingSource.DataSource = _team.UsersAttending.ToList();            
            _connectionDb.ConnectionContext.Users.Load();
            _userBindingSource.DataSource = _connectionDb.ConnectionContext.Users.Local.ToBindingList();
            gridTeamUsers.AutoGenerateColumns = false;
            AddColumns();
            gridTeamUsers.DataSource = _teamUserBindingSource;
            gridTeamUsers.ShowHeaderCellButtons = true;
            gridTeamUsers.ShowFilteringRow = false;
            gridTeamUsers.EnableFiltering = true;
            gridTeamUsers.FilterPopupRequired += (sender, args) => args.FilterPopup = new RadListFilterPopup(args.Column, true);
            gridTeamUsers.UserAddedRow += (sender, args) =>
            {
                var teams = _connectionDb.ConnectionContext.Teams.Single(t => t.Id == team.Id);
                teams.UsersAttending.Add((User) _userBindingSource.Current);
                Save();
            };

            gridTeamUsers.UserDeletedRow += (sender, args) =>
            {
                var teams = _connectionDb.ConnectionContext.Teams.Single(t => t.Id == team.Id);
                teams.UsersAttending.Remove((User) _userBindingSource.Current);
                Save();
            };
            gridTeamUsers.UserDeletedRow += (sender, args) => Save();
            RadGridLocalizationProvider.CurrentProvider = new RussianRadGridLocalizationProvider();
            gridTeamUsers.TableElement.UpdateView();
            gridTeamUsers.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill; 
        }

        private void AddColumns()
        {
            var userNameColumn = new GridViewComboBoxColumn();
            userNameColumn.Name = "UserName";
            userNameColumn.HeaderText = "Игрок";
            userNameColumn.DataSource = _userBindingSource;
            userNameColumn.ValueMember = "Id";
            userNameColumn.DisplayMember = "Name";
            userNameColumn.FieldName = "Id";
            gridTeamUsers.Columns.Add(userNameColumn);
        }

        private void Save()
        {
            try
            {
                _connectionDb.ConnectionContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }
    }
}
