namespace DartsWin
{
    public interface IGameFinisher
    {
        bool IsGameFinished(int totalPoints, DartsSerie lastSerie);
    }
}