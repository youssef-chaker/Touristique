using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TouristiqueDbContext.models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Adress { get; set; }
        public int Etoile { get; set; }
        public Restaurant Restaurant { get; set; }
        public virtual ICollection<Chambre> Chambres { get; set; }
        public virtual ICollection<TransportHotel> TransportHotels { get; set; }
    }
}