using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DartsConsole;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace DartsWin
{
    public partial class GameSettingsForm : RadForm
    {
        private readonly List<Team> _members = new List<Team>();
        private readonly BindingSource _membersBindingSource = new BindingSource();
        private readonly BindingSource _rulesBindingSource = new BindingSource();
        private readonly BindingSource _teamsBindingSource = new BindingSource();
        private readonly BindingSource _usersBindingSource = new BindingSource();
        private readonly Db _connectionDb;

        public GameSettingsForm(Db connectionDb)
        {
            InitializeComponent();
            _connectionDb = connectionDb;
            _connectionDb.ConnectionContext.Rules.Load();
            _connectionDb.ConnectionContext.Teams.Load();
            _rulesBindingSource.DataSource = _connectionDb.ConnectionContext.Rules.Local.ToBindingList();
            _usersBindingSource.DataSource =
                _connectionDb.ConnectionContext.Teams.Local.ToBindingList()
                    .Where(t => t.UsersAttending.Count == 1).ToList();
            _teamsBindingSource.DataSource = _connectionDb.ConnectionContext.Teams.Local.ToBindingList()
                .Where(t => t.UsersAttending.Count > 1).ToList();

            gridMembers.ShowGroupPanel = false;
            gridMembers.MasterTemplate.EnableGrouping = false;
            gridMembers.AutoGenerateColumns = false;
            gridMembers.AllowAddNewRow = true;
            gridMembers.ShowHeaderCellButtons = true;
            gridMembers.ShowFilteringRow = false;
            gridMembers.EnableFiltering = true;
            gridMembers.FilterPopupRequired +=
                (sender, args) => args.FilterPopup = new RadListFilterPopup(args.Column, true);
            RadGridLocalizationProvider.CurrentProvider = new RussianRadGridLocalizationProvider();
            gridMembers.TableElement.UpdateView();
            gridMembers.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

            _membersBindingSource.DataSource = _members;
            gridMembers.DataSource = _membersBindingSource;
            AddColumns();

            cmbGameRule.DataSource = _rulesBindingSource;
            cmbGameRule.ValueMember = "Id";
            cmbGameRule.DisplayMember = "Name";
            cmbGameRule.MultiColumnComboBoxElement.Columns["Id"].IsVisible =
                cmbGameRule.MultiColumnComboBoxElement.Columns["Id"].VisibleInColumnChooser = 
                cmbGameRule.MultiColumnComboBoxElement.Columns["Description"].IsVisible =
                cmbGameRule.MultiColumnComboBoxElement.Columns["Description"].VisibleInColumnChooser = false;
            cmbGameRule.MultiColumnComboBoxElement.Columns["Name"].HeaderText = "Игра";
            cmbGameRule.MultiColumnComboBoxElement.Columns["Name"].Width = 60;
            cmbGameRule.MultiColumnComboBoxElement.Columns["IsCommand"].HeaderText = "Командная";
            cmbGameRule.MultiColumnComboBoxElement.Columns["IsCommand"].Width = 75;
            cmbGameRule.MultiColumnComboBoxElement.AutoSizeDropDownHeight = true;
            cmbGameRule.MultiColumnComboBoxElement.AutoSizeMode = RadAutoSizeMode.FitToAvailableSize;
        }

        private void AddColumns()
        {
            var memberNameColumns = new GridViewComboBoxColumn
            {
                Name = "MemberName",
                HeaderText = "Участник",
                ValueMember = "Id",
                DisplayMember = "Name",
                FieldName = "Id"
            };
            gridMembers.Columns.Add(memberNameColumns);
        }

        private void cmbGameRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rule = _rulesBindingSource.Current as Rule;
            if (rule != null)
            {
                (gridMembers.Columns["MemberName"] as GridViewComboBoxColumn).DataSource = rule.IsCommand ? _teamsBindingSource : _usersBindingSource;
            }
        }

        private void btnBeginGame_Click(object sender, EventArgs e)
        {            
            try
            {
                var gameHeader = CreateGameHeader();
                using (var gameForm = new GameForm(_connectionDb, _rulesBindingSource.Current as Rule, _members, gameHeader))
                {
                    gameForm.ShowDialog();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private GameHeader CreateGameHeader()
        {
            var gameHeader = new GameHeader
            {
                BeginTimestamp = DateTime.Now,
                Rule = _rulesBindingSource.Current as Rule
            };
            _connectionDb.ConnectionContext.GameHeaders.Add(gameHeader);
            _connectionDb.ConnectionContext.SaveChanges();
            return gameHeader;
        }
    }
}