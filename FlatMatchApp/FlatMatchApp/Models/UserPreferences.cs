﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlatMatchApp.Models
{
    public class UserPreferences
    {
        [Key]
        public int Id { get; set; }
        //Probably won't ever use the Key in the actual program
        public int UserId { get; set; }
        public int PreferenceId { get; set; }
        public int Value { get; set; }
    }
}