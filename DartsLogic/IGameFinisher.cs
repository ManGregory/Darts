namespace DartsLogic
{
    public interface IGameFinisher
    {
        bool IsGameFinished(int totalPoints, DartsSerie lastSerie);
    }
}