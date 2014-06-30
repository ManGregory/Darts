using System.Collections.Generic;
using System.Globalization;

namespace DartsLogic
{
    public class DartsScore
    {
        private Dictionary<int, string> _factorChars = new Dictionary<int, string>()
        {
            {1, "S"},
            {2, "D"},
            {3, "T"}
        };

        public int Sector { get; set; }
        public int Factor { get; set; }

        public bool IsDouble
        {
            get
            {
                return Factor == 2;
            }
        }

        public bool IsTriple
        {
            get
            {
                return Factor == 3;
            }
        }

        public DartsScore(int sector, int factor)
        {
            Sector = sector;
            Factor = factor;
        }

        public DartsScore()
        {
            
        }

        public override string ToString()
        {
            return string.Format("{0} * {1}", Sector, Factor);
        }

        public int GetSum()
        {
            return Sector*Factor;
        }

        private string GetSectorChar()
        {
            return Sector == 25 ? "B" : Sector.ToString(CultureInfo.InvariantCulture);
        }

        public string ToString(bool shortForm)
        {
            return string.Format("{0}{1}", _factorChars[Factor], GetSectorChar());
        }
    }
}
