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

namespace DartsWin
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        private Db connectionDb = new Db();

        public MainForm()
        {
            InitializeComponent();
            Database.SetInitializer(new CreateDatabaseIfNotExists<DartsContext>());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            using (var usersForm = new UsersForm(connectionDb))
            {
                usersForm.ShowDialog(this);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {            
            connectionDb.ConnectionContext.Dispose();
        }

        private void btnTeams_Click(object sender, EventArgs e)
        {
            using (var teamsForm = new TeamsForm(connectionDb))
            {
                teamsForm.ShowDialog(this);
            }
        }
    }
}
