using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DartsConsole;
using Telerik.WinControls;
using Telerik.WinControls.UI;

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

        private IEnumerable<Control> EnumerateControls()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(Control).IsAssignableFrom(field.FieldType)
                   let component = (Control)field.GetValue(this)
                   where component != null
                   select component;
        }

        private void ThrowEditValueChanged(object sender, EventArgs eventArgs)
        {
            var edit = (sender as NumericUpDown);
            if (edit != null)
            {
                var lastNum = edit.Name.Substring(edit.Name.Length - 1);
                var throwLabelSum = EnumerateControls().Single(e => e.Name == "lblSumThrow" + lastNum) as RadLabel;
                var throwEdit = EnumerateControls().Single(e => e.Name == "edThrow" + lastNum) as NumericUpDown;
                var throwFactor = EnumerateControls().Single(e => e.Name == "edFactor" + lastNum) as NumericUpDown;
                if (throwLabelSum != null && throwEdit != null && throwFactor != null)
                {
                    throwLabelSum.Text = (throwEdit.Value*throwFactor.Value).ToString();
                }
            }
            lblSumSerie.Text = GetSerieSum().ToString();
        }

        private decimal GetSerieSum()
        {
            return
                (edThrow1.Value*edFactor1.Value) +
                (edThrow2.Value*edFactor2.Value) +
                (edThrow3.Value*edFactor3.Value);
        }

        private string GetFormText()
        {
            return _rule.IsCommand
                ? string.Format("Командная игра - {0}", _rule.Name)
                : string.Format("Игра - {0}", _rule.Name);
        }
    }
}
