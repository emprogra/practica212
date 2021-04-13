using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Work3.Models
{
    public class Dato
    {
        [Key]
        public int PerosnId { get; set; }
        [Required]
        public string Name { get; set; }
        public int CovidCount { get; set; }
    }
}