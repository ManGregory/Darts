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
            return (
                (totalPoints + lastSerie.GetSum() == Limit) &&
                (lastSerie.Throws.Last(t => t.GetSum() > 0).Score.IsDouble));
        }

        public override bool IsGameBusted(int totalPoints, DartsSerie lastSerie)
        {
            return (
                !IsGameFinished(totalPoints, lastSerie) &&
                (totalPoints + lastSerie.GetSum() >= Limit - 1));
        }
    }
}
