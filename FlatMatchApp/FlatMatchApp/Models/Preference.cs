﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace FlatMatchApp.Models
{
    public class Preference
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //Might not need name for actual usage, but should be helpful
    }
}
