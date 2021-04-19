using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TouristiqueDbContext.models
{
    public class NoteRestaurant
    {
        public int Id { get; set; }
        [Required]
        public virtual IdentityUser User { get; set; }
        [Required]
        public int Etoile { get; set; }
        [Required]
        public virtual Restaurant Restaurant { get; set; }
    }
}