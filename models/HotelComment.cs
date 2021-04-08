using Microsoft.AspNetCore.Identity;

namespace TouristiqueDbContext.models
{
    public class HotelComment
    {
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public IdentityUser User { get; set; }
        public string Comment { get; set; }
    }
}