using System;
using System.ComponentModel.DataAnnotations;

namespace President.Domain
{
    public class PresidentInfo
    {
        [Key]
        public string PresidentName { get; set; }
        public DateTime Birthday { get; set; }
        public string Birthplace { get; set; }
        public DateTime? Deathday { get; set; }
        public string Deathplace { get; set; }
    }
}
