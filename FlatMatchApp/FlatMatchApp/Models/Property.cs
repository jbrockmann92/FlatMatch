using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlatMatchApp.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        public string Activities { get; set; }
        public double SquareFootage { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public int NumberBedrooms { get; set; }
        public bool isAvailable { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

    }
}
