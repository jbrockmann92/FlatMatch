using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlatMatchApp.Models
{
    public class Leaseholder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public Address Address { get; set; }
        [ForeignKey("IdentityUser")]
        [Display(Name = "Identity User")]
        public string UserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
