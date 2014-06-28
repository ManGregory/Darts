namespace DartsLogic
{
    public class DartsThrow
    {
        public int Number { get; set; }
        public DartsScore Score { get; set; }

        public DartsThrow(int number, DartsScore score)
        {
            Number = number;
            Score = score;
        }

        public int GetSum()
        {
            return Score.GetSum();
        }
    }
}
