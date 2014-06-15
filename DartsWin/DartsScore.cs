using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsWin
{
    public class DartsScore
    {
        public int Sector { get; set; }
        public int Factor { get; set; }

        public DartsScore(int sector, int factor)
        {
            Sector = sector;
            Factor = factor;
        }

        public DartsScore()
        {
            
        }
    }
}
