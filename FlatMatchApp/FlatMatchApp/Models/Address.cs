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
        public string StreetName { get; set; }
        public string ApartmentNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
    }
}
