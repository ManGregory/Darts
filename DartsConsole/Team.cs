using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsConsole
{
    public class Team
    {
        public int Id { get; set; }

        [StringLength(200)]        
        public string Name { get; set; }

        public virtual ICollection<User> UsersAttending { get; set; }

        public Team()
        {
            UsersAttending = new HashSet<User>();
        }
    }
}
