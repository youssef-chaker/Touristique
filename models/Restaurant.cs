using System;

namespace TouristiqueDbContext.models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Num { get; set; }
        public string Cuisine { get; set; }
        public string Type { get; set; }
        public Location Location { get; set; }
    }
}