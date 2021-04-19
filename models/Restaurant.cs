using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TouristiqueDbContext.models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public int Num { get; set; }
        public string Type { get; set; }
        public virtual ICollection<NoteRestaurant> Notes { get; set; }
        [Required]
        public virtual Location Location { get; set; }
        public virtual ICollection<RestaurantComment> Comments { get; set; }
    }
}