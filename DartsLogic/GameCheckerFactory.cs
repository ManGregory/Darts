using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DartsConsole;

namespace DartsLogic
{
    public static class GameCheckerFactory
    {
        public static GameChecker GetGameChecker(Rule rule) 
        {
            if (rule.Name == "301") return new GameCheckerBust301();
            return new GameCheckerBust501();
        }
    }
}
