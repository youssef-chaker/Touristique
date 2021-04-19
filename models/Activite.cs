using System.ComponentModel.DataAnnotations;

namespace TouristiqueDbContext.models
{
    public class Activite
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public string Genre { get; set; }
        public float Prix { get; set; }
    }
}