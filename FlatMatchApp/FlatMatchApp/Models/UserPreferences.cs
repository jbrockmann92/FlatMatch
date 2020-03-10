using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlatMatchApp.Models
{
    public class UserPreferences
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("IdentityUser")]
        [Display(Name = "Identity User")]
        public string UserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [ForeignKey("PreferenceName")]
        [Display(Name = "Preference Id")]
        public int PreferenceId { get; set; }
        public Preference PreferenceName { get; set; }
        public int Value { get; set; }
    }
}
