using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TouristiqueDbContext.models
{
    public class NoteHotel
    {
        public int Id { get; set; }
        [Required]
        public virtual IdentityUser User { get; set; }
        [Required]
        public int Etoile { get; set; }
        [Required]
        public virtual Hotel Hotel { get; set; }
    }
}