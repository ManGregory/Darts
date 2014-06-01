using System.Data.Common;
using System.Data.Entity;

namespace DartsConsole
{
    public class DartsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<GameHeader> GameHeaders { get; set; }
        public DbSet<GameLine> GameLines { get; set; }

        public DartsContext() : base("darts")
        {
            
        }

        public DartsContext(DbConnection connection) : base(connection, true)
        {
            
        }
    }
}
