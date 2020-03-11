using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlatMatchApp.Models
{
    public class Renter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [ForeignKey("IdentityUser")]
        [Display(Name = "Identity User")]
        public string UserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [NotMapped]
        public List<Preference> Preferences { get; set; }
        [Display(Name = "Link to Facebook")]
        public string FacebookSocial { get; set; }
        [Display(Name = "Link to Instagram")]
        public string InstagramSocial { get; set; }
        [Display(Name = "Link to Twitter")]
        public string TwitterSocial { get; set; }
        [Display(Name = "Add a Profile Image")]
        public string  ProfileUrl { get; set; }

    }
}
