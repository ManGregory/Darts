using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsConsole
{
    public class GameHeader
    {
        public int Id { get; set; }
        public DateTime BeginTimestamp { get; set; }
        public DateTime? EndTimestamp { get; set; }

        public int RuleId { get; set; }
        public virtual Rule Rule { get; set; }

        public int? TeamWinnerId { get; set; }
        public virtual Team TeamWinner { get; set; }
    }

    public class GameLine
    {
        public int Id { get; set; }
        public int Sector { get; set; }
        public int Factor { get; set; }

        public int GameHeaderId { get; set; }
        public virtual GameHeader GameHeader { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
