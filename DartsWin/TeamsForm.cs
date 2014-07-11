using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DartsConsole;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace DartsWin
{
    public partial class TeamsForm : Telerik.WinControls.UI.RadForm
    {
        private Db _connectionDb;
        private BindingSource _teamsBindingSource = new BindingSource();

        public TeamsForm(Db connectionDb)
        {
            InitializeComponent();
            _connectionDb = connectionDb;
            _connectionDb.ConnectionContext.Teams.Load();
            _teamsBindingSource.DataSource = _connectionDb.ConnectionContext.Teams
                .Local.ToBindingList();
            gridTeams.DataSource = _teamsBindingSource;
            gridTeams.Columns["Name"].HeaderText = "Название";
            gridTeams.Columns["UsersAttending"].ReadOnly = true;
            gridTeams.Columns["UsersAttending"].HeaderText = "Игроки";
            gridTeams.Columns["Id"].IsVisible = false;
            gridTeams.Columns["Id"].VisibleInColumnChooser = false;
            gridTeams.CellDoubleClick += (sender, args) =>
            {
                if (args.ColumnIndex == 2)
                {
                    using (var teamUsers = new TeamUsers(_connectionDb, (Team) _teamsBindingSource.Current))
                    {
                        teamUsers.ShowDialog(this);
                    }
                }
            };
            gridTeams.ShowHeaderCellButtons = true;
            gridTeams.ShowFilteringRow = false;
            gridTeams.EnableFiltering = true;
            gridTeams.FilterPopupRequired += (sender, args) => args.FilterPopup = new RadListFilterPopup(args.Column, true);
            gridTeams.UserAddedRow += (sender, args) => Save();
            gridTeams.CellEndEdit += (sender, args) => Save();
            gridTeams.UserDeletedRow += (sender, args) => Save();
            RadGridLocalizationProvider.CurrentProvider = new RussianRadGridLocalizationProvider();
            gridTeams.TableElement.UpdateView();
            gridTeams.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;           
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
