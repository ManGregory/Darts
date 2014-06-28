using System.Collections.Generic;
using System.Linq;

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
    }
}
