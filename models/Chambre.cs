using System;
using System.ComponentModel.DataAnnotations;

namespace TouristiqueDbContext.models
{
    public class Chambre
    {
        public int Id { get; set; }
        [Required]
        public int Num { get; set; }
        [Required]
        public string Type { get; set; } 
        [Required]
        public float Prix { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}