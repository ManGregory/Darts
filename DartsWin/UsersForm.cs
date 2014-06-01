using System;
using System.Collections.Generic;
using System.Linq;
using DartsConsole;

namespace DartsWin
{
    public partial class UsersForm : Telerik.WinControls.UI.RadForm
    {
        private Db _connectionDb;

        public UsersForm(Db connectionDb)
        {
            InitializeComponent();
            _connectionDb = connectionDb;
            var users = _connectionDb.ConnectionContext.Users.ToList();
            gridUsers.DataSource = users;
            // todo set columns width and other attrs
            gridUsers.Columns["Id"].IsVisible = false;
            gridUsers.Columns["TeamsAttending"].IsVisible = false;
        }

        private void gridUsers_UserAddedRow(object sender, Telerik.WinControls.UI.GridViewRowEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // todo saving changes in db            
        }
    }
}
