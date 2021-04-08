using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TouristiqueDbContext.models
{
    public class RestaurantComment
    {
        public int Id { get; set; }
        public Restaurant Restaurant { get; set; }
        public IdentityUser User { get; set; }
        public string Comment { get; set; }
        public virtual ICollection<RestaurantComment> Comments { get; set; }

    }
}