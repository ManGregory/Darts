﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsConsole
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Email { get; set; }

        public virtual ICollection<Team> TeamsAttending { get; set; }

        public User()
        {
            TeamsAttending = new HashSet<Team>();
        }
    }
}
