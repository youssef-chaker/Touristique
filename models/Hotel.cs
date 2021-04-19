using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TouristiqueDbContext.models
{
    public class Hotel
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public virtual ICollection<NoteHotel> Notes { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        [Required]
        public virtual Location Location { get; set; }
        public virtual ICollection<Chambre> Chambres { get; set; }
        public virtual ICollection<TransportHotel> TransportHotels { get; set; }
        public virtual ICollection<HotelComment> Comments { get; set; }
        
    }
}