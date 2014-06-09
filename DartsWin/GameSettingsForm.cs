﻿using System;
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
        private readonly List<Member> _members = new List<Member>();
        private readonly BindingSource _membersBindingSource = new BindingSource();
        private readonly BindingSource _rulesBindingSource = new BindingSource();
        private readonly BindingSource _teamsBindingSource = new BindingSource();
        private readonly BindingSource _usersBindingSource = new BindingSource();
        private Db _connectionDb;

        public GameSettingsForm(Db connectionDb)
        {
            InitializeComponent();
            _connectionDb = connectionDb;
            _connectionDb.ConnectionContext.Rules.Load();
            _connectionDb.ConnectionContext.Teams.Load();
            _connectionDb.ConnectionContext.Users.Load();
            _rulesBindingSource.DataSource = _connectionDb.ConnectionContext.Rules.Local.ToBindingList()
                .Select(r => new {r.Name, r.IsCommand});
            _usersBindingSource.DataSource = _connectionDb.ConnectionContext.Users.Local.ToBindingList();
            _teamsBindingSource.DataSource = _connectionDb.ConnectionContext.Teams.Local.ToBindingList();

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
            cmbGameRule.MultiColumnComboBoxElement.Columns[0].HeaderText = "Игра";
            cmbGameRule.MultiColumnComboBoxElement.Columns[0].Width = 60;
            cmbGameRule.MultiColumnComboBoxElement.Columns[1].HeaderText = "Командная";
            cmbGameRule.MultiColumnComboBoxElement.Columns[1].Width = 75;
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
            dynamic rule = _rulesBindingSource.Current;
            if (rule != null)
            {
                if (rule.IsCommand)
                {
                    (gridMembers.Columns["MemberName"] as GridViewComboBoxColumn).DataSource = _teamsBindingSource;
                }
                else
                {
                    (gridMembers.Columns["MemberName"] as GridViewComboBoxColumn).DataSource = _usersBindingSource;
                }
            }
        }

        private void btnBeginGame_Click(object sender, EventArgs e)
        {
            var a = _members.Count;
        }
    }
}