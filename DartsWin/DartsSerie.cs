using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsWin
{
    class DartsSerie
    {
        public List<DartsThrow> Throws = new List<DartsThrow>();

        public DartsSerie(IEnumerable<DartsThrow> throws)
        {
            Throws.AddRange(throws);
        }

        public int GetSum()
        {
            return Throws.Sum(t => t.GetSum());
        }
    }
}
