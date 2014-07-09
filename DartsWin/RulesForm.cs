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
    public partial class RulesForm :  Telerik.WinControls.UI.RadForm
    {
        private Db _connectionDb;
        private BindingSource _rulesBindingSource = new BindingSource();

        public RulesForm(Db connectionDb)
        {
            InitializeComponent();
            _connectionDb = connectionDb;
            _connectionDb.ConnectionContext.Rules.Load();
            _rulesBindingSource.DataSource = _connectionDb.ConnectionContext.Rules
                .Local.ToBindingList();
            gridRules.DataSource = _rulesBindingSource;
            gridRules.Columns["Name"].HeaderText = "Название";
            gridRules.Columns["Description"].HeaderText = "Описание";
            gridRules.Columns["Description"].WrapText = true;
            gridRules.Columns["IsCommand"].HeaderText = "Командная";
            gridRules.Columns["Id"].IsVisible = false;
            gridRules.Columns["Id"].VisibleInColumnChooser = false;
            gridRules.ShowHeaderCellButtons = true;
            gridRules.ShowFilteringRow = false;
            gridRules.EnableFiltering = true;
            gridRules.FilterPopupRequired += (sender, args) => args.FilterPopup = new RadListFilterPopup(args.Column, true);
            gridRules.CellEndEdit += (sender, args) => Save();
            gridRules.UserDeletedRow += (sender, args) => Save();
            gridRules.CellEditorInitialized += (sender, args) =>
            {
                if (args.Column.Name != "IsCommand")
                {
                    ((args.ActiveEditor as RadTextBoxEditor).EditorElement as RadTextBoxEditorElement).TextBoxItem
                        .Multiline
                        = true;
                    ((args.ActiveEditor as RadTextBoxEditor).EditorElement as RadTextBoxEditorElement).TextBoxItem
                        .ScrollBars = ScrollBars.Vertical;
                    ((args.ActiveEditor as RadTextBoxEditor).EditorElement as RadTextBoxEditorElement).TextBoxItem
                        .AcceptsReturn = true;
                }
            };
            RadGridLocalizationProvider.CurrentProvider = new RussianRadGridLocalizationProvider();
            gridRules.TableElement.UpdateView();
            gridRules.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
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
