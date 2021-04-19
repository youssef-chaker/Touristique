using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TouristiqueDbContext.models
{
    public class HotelComment
    {
        public int Id { get; set; }
        [Required]
        public Hotel Hotel { get; set; }
        [Required]
        public IdentityUser User { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}