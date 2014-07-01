using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsLogic
{
    public abstract class GameChecker : IGameFinisher, IGameBuster
    {
        public virtual bool IsGameFinished(int totalPoints, DartsSerie lastSerie)
        {
            return false;
        }

        public virtual bool IsGameBusted(int totalPoints, DartsSerie lastSerie)
        {
            return false;
        }
    }
}
