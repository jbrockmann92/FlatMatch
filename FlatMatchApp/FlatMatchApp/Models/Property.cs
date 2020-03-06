using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlatMatchApp.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        public string Activities { get; set; }
        [Required]
        public double SquareFootage { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int NumberBedrooms { get; set; }

        public bool isAvailable { get; set; }

    }
}
