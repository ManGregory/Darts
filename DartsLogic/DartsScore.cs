namespace DartsLogic
{
    public class DartsScore
    {
        public int Sector { get; set; }
        public int Factor { get; set; }

        public bool IsDouble
        {
            get
            {
                return Factor == 2;
            }
        }

        public bool IsTriple
        {
            get
            {
                return Factor == 3;
            }
        }

        public DartsScore(int sector, int factor)
        {
            Sector = sector;
            Factor = factor;
        }

        public DartsScore()
        {
            
        }

        public override string ToString()
        {
            return string.Format("{0} * {1}", Sector, Factor);
        }

        public int GetSum()
        {
            return Sector*Factor;
        }
    }
}
