using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsConsole
{
    class DartsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<GameHeader> GameHeaders { get; set; }
        public DbSet<GameLine> GameLines { get; set; }

        public DartsContext() : base("darts")
        {
            
        }
    }
}
