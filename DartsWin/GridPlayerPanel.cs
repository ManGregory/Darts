using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace DartsWin
{
    public partial class GridPlayerPanel : UserControl
    {
        public GridPlayerPanel()
        {
            InitializeComponent();
            gridTeam.EnableFiltering = true;
            gridTeam.ShowFilteringRow = false;
            gridTeam.AutoGenerateColumns = false;
            gridTeam.FilterPopupRequired +=
                (sender, args) => args.FilterPopup = new RadListFilterPopup(args.Column, true);
            gridTeam.ShowGroupPanel = false;
            gridTeam.AutoGenerateColumns = false;
            gridTeam.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            RadGridLocalizationProvider.CurrentProvider = new RussianRadGridLocalizationProvider();
        }

        public RadGridView TeamGrid
        {
            get
            {
                return gridTeam;
            }
        }

        public RadPanel NamePanel
        {
            get
            {
                return pnlTeamName;
            }
        }

        public RadPanel StatusPanel
        {
            get
            {
                return pnlTeamStatus;
            }
        }
    }
}
