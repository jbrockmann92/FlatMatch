using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlatMatchApp.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Street")]
        public string StreetName { get; set; }
        [Display(Name = "City")]
        public string ApartmentNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
    }
}
