using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace DartsWin
{
    public partial class UsersForm : Telerik.WinControls.UI.RadForm
    {
        private Db _connectionDb;
        private BindingSource _usersBindingSource = new BindingSource();

        public UsersForm(Db connectionDb)
        {
            // todo save cell formatting
            InitializeComponent();
            _connectionDb = connectionDb;
            _connectionDb.ConnectionContext.Users.Load();
            _usersBindingSource.DataSource = _connectionDb.ConnectionContext.Users
                .Local.ToBindingList().Select(u => new {Name = u.Name, Email = u.Email});
            gridUsers.DataSource = _usersBindingSource;
            gridUsers.ShowHeaderCellButtons = true;
            gridUsers.ShowFilteringRow = false;
            gridUsers.EnableFiltering = true;
            gridUsers.FilterPopupRequired += gridUsers_FilterPopupRequired;
            RadGridLocalizationProvider.CurrentProvider = new RussianRadGridLocalizationProvider();
            gridUsers.TableElement.UpdateView();
            gridUsers.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            // todo set columns width and other attrs
            /*gridUsers.Columns["Id"].IsVisible = false;}
            gridUsers.Columns["TeamsAttending"].IsVisible = false;
            gridUsers.Columns["TeamsAttending"].ReadOnly = true;
            gridUsers.Columns["TeamsAttending"].HeaderText = "Команды";
            gridUsers.Columns["TeamsAttending"].Width = 100;*/
            gridUsers.Columns["Name"].Width = 200;
            gridUsers.Columns["Name"].HeaderText = "Игрок";
            gridUsers.Columns["Email"].Width = 300;            
        }

        private void gridUsers_FilterPopupRequired(object sender, FilterPopupRequiredEventArgs e)
        {
            e.FilterPopup = new RadListFilterPopup(e.Column);
        }

        private void gridUsers_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
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
