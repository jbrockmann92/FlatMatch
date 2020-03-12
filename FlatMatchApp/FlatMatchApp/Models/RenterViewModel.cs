using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlatMatchApp.Models
{
    public class RenterViewModel
    {
        public Renter Renter { get; set; }
        public List<Preference> Preferences { get; set; }
        public List<int> Value { get; set; }
        public Leaseholder Leaseholder { get; set; }
        public List<Leaseholder> Leaseholders { get; set; }
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileUrl { get; set; }
        public List<UserPreferences> UserPreferences { get; set; }

    }
}
