using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace DartsWin
{
    class DartsThrow
    {
        public int Number { get; set; }
        public DartsScore Score { get; set; }

        public DartsThrow(int number, DartsScore score)
        {
            Number = number;
            Score = score;
        }
    }
}
