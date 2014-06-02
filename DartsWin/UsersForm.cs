using System;
using System.Data.Entity;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace DartsWin
{
    public partial class UsersForm : Telerik.WinControls.UI.RadForm
    {
        private Db _connectionDb;
        private BindingSource _usersBindingSource = new BindingSource();

        public UsersForm(Db connectionDb)
        {
            InitializeComponent();
            _connectionDb = connectionDb;
            _connectionDb.ConnectionContext.Users.Load();
            _usersBindingSource.DataSource = _connectionDb.ConnectionContext.Users.Local.ToBindingList();
            gridUsers.DataSource = _usersBindingSource;
            // todo add excel like filtering

            // todo add localisation

            gridUsers.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            // todo set columns width and other attrs
            gridUsers.Columns["Id"].IsVisible = false;
            gridUsers.Columns["TeamsAttending"].IsVisible = false;
            gridUsers.Columns["TeamsAttending"].ReadOnly = true;
            gridUsers.Columns["TeamsAttending"].HeaderText = "Команды";
            gridUsers.Columns["TeamsAttending"].Width = 100;
            gridUsers.Columns["Name"].Width = 200;
            gridUsers.Columns["Name"].HeaderText = "Игрок";
            gridUsers.Columns["Email"].Width = 300;            
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
