﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlatMatchApp.Models
{
    public class RenterViewModel
    {
        public Renter Renter { get; set; }
        public List<Preference> Preferences { get; set; }
    }
}
