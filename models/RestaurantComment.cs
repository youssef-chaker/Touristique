using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TouristiqueDbContext.models
{
    public class RestaurantComment
    {
        public int Id { get; set; }
        [Required]
        public Restaurant Restaurant { get; set; }
        [Required]
        public IdentityUser User { get; set; }
        [Required]
        public string Comment { get; set; }

    }
}