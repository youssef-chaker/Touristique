using System.Collections.Generic;
using TouristiqueDbContext.models;

namespace TouristiqueMvc.Models
{
    public class HotelViewModel
    {
        public List<Hotel> Hotels { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
    }
}