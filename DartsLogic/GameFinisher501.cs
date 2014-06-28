using System.Linq;

namespace DartsLogic
{
    // todo make abstract class for game with limit

    public class GameFinisher501 : IGameFinisher, IGameBuster
    {
        public bool IsGameFinished(int totalPoints, DartsSerie lastSerie)
        {
            return (
                (totalPoints + lastSerie.GetSum() == 501) && 
                (lastSerie.Throws.Last(t => t.GetSum() > 0).Score.IsDouble));
        }

        public bool IsGameBusted(int totalPoints, DartsSerie lastSerie)
        {
            return (
                !IsGameFinished(totalPoints, lastSerie) && 
                (totalPoints + lastSerie.GetSum() >= 500));
        }
    }
}
