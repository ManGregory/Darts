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
            // todo add users to team
            InitializeComponent();
            _connectionDb = connectionDb;
            _connectionDb.ConnectionContext.Teams.Load();
            _teamsBindingSource.DataSource = _connectionDb.ConnectionContext.Teams
                .Local.ToBindingList().Select(t => new { Name = t.Name, UsersAttending = t.UsersAttending });            
            gridTeams.DataSource = _teamsBindingSource;
            gridTeams.Columns[0].HeaderText = "Название";
            gridTeams.Columns[0].ReadOnly = false;
            gridTeams.Columns[1].HeaderText = "Игроки";
            gridTeams.CellDoubleClick += (sender, args) =>
            {

            };
            gridTeams.ShowHeaderCellButtons = true;
            gridTeams.ShowFilteringRow = false;
            gridTeams.EnableFiltering = true;
            gridTeams.FilterPopupRequired += (sender, args) => args.FilterPopup = new RadListFilterPopup(args.Column, true);
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
