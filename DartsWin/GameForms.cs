using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DartsConsole;
using Telerik.WinControls;

namespace DartsWin
{
    public partial class GameForm : Telerik.WinControls.UI.RadForm
    {
        private Db _connectionDb;
        private DartsConsole.Rule _rule;
        private GameHeader _gameHeader;
        private BindingSource _membersBindingSource = new BindingSource();

        public GameForm(Db connectionDb, DartsConsole.Rule rule, List<Member> members, GameHeader gameHeader)
        {
            InitializeComponent();
            _connectionDb = connectionDb;
            _gameHeader = gameHeader;
            _rule = rule;
            if (rule.IsCommand)
            {
                _connectionDb.ConnectionContext.Teams.Load();
                _membersBindingSource.DataSource = _connectionDb.ConnectionContext.Teams.Local.ToBindingList()
                    .Where(m => members.Exists(m1 => m1.Id == m.Id));
            }
            else
            {
                _connectionDb.ConnectionContext.Users.Load();
                _membersBindingSource.DataSource = _connectionDb.ConnectionContext.Users.Local.ToBindingList()
                    .Where(m => members.Exists(m1 => m1.Id == m.Id));
            }
            Text = GetFormText();
            txtRuleDescription.Text = _rule.Description;
            txtRuleDescription.IsReadOnly = true;
            txtRuleDescription.DeselectAll();
        }

        private string GetFormText()
        {
            return _rule.IsCommand
                ? string.Format("Командная игра - {0}", _rule.Name)
                : string.Format("Игра - {0}", _rule.Name);
        }
    }
}
