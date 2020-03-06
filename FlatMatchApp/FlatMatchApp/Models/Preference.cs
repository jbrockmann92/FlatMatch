using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace FlatMatchApp.Models
{
    public class Preference
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Exists { get; set; }
        public int Value { get; set; }
    }
}
