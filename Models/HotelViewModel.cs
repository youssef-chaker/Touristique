using System.Collections.Generic;
using TouristiqueDbContext.models;

namespace TouristiqueMvc.Models
{
    public class HotelViewModel
    {
        public List<Hotel> Hotels { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public Hotel Hotel { get; set; }
        public Chambre Chambre { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}