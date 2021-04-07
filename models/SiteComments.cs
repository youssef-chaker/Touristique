using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TouristiqueDbContext.models
{
    public class SitesComments
    {
        public int Id { get; set; }
        public Site Site { get; set; }
        public IdentityUser User { get; set; }
        public virtual ICollection<SitesComments> Comments { get; set; }
    }
}