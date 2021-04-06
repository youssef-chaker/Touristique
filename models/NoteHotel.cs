using Microsoft.AspNetCore.Identity;

namespace TouristiqueDbContext.models
{
    public class NoteHotel
    {
        public int Id { get; set; }
        public virtual IdentityUser User { get; set; }
        public int Etoile { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}