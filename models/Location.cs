using System.ComponentModel.DataAnnotations;

namespace TouristiqueDbContext.models
{
    public class Location
    {
        public int Id { get; set; }
        public string Adresse { get; set; }
        [Required]
        public string Ville { get; set; }
        [Required]
        public string Pays { get; set; }
    }
}