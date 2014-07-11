using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsLogic
{
    public abstract class GameCheckerBust : GameChecker
    {
        protected int Limit;

        public override bool IsGameFinished(int totalPoints, DartsSerie lastSerie)
        {
            var lastThrow = lastSerie.Throws.OrderBy(t => t.Number).LastOrDefault(t => t.GetSum() > 0);
            return lastThrow != null && (
                (totalPoints + lastSerie.GetSum() == Limit) &&
                (lastThrow.Score.IsDouble));
        }

        public override bool IsGameBusted(int totalPoints, DartsSerie lastSerie)
        {
            return (
                !IsGameFinished(totalPoints, lastSerie) &&
                (totalPoints + lastSerie.GetSum() >= Limit - 1));
        }
    }
}
