﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlatMatchApp.Models
{
    public class LeaseholdersViewModel
    {
        public Renter Renter { get; set; }
        public List<Preference> Preferences { get; set; }
        public int Value { get; set; }
        public Leaseholder Leaseholder { get; set; }
        public List<Leaseholder> Leaseholders { get; set; }
    }
}
