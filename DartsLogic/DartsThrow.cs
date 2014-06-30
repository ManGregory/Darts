using System;

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

        public override string ToString()
        {
            return String.Format("({0}, {1})", Number, Score);
        }

        public string ToString(bool shortForm)
        {
            return String.Format("{0}", Score.ToString(shortForm));
        }
    }
}
