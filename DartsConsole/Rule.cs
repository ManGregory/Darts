﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsConsole
{
    public class Rule
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean IsCommand { get; set; }
    }
}
