using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DartsLogic
{
    public class DartsSerie
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

        public override string ToString()
        {
            return string.Join(",", Throws);
        }

        public string ToString(bool shortForm)
        {
            return string.Join(" ", Throws.Select(t => t.ToString(shortForm)));
        }
    }
}
