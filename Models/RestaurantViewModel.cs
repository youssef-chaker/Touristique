using System.Collections.Generic;
using TouristiqueDbContext.models;

namespace TouristiqueMvc.Models
{
    public class RestaurantViewModel
    {
        public List<Restaurant> Restaurants { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}