using Microsoft.AspNetCore.Identity;

namespace TouristiqueDbContext.models
{
    public class NoteSite
    {
        public int Id { get; set; }
        public virtual IdentityUser User { get; set; }
        public int Etoile { get; set; }
        public virtual Site Site { get; set; }
    }
}