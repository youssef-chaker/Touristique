using Microsoft.AspNetCore.Identity;

namespace TouristiqueDbContext.models
{
    public class NoteRestaurant
    {
        public int Id { get; set; }
        public virtual IdentityUser User { get; set; }
        public int Etoile { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}