using System;
using System.Collections.Generic;

namespace TouristiqueDbContext.models
{
    public class Site
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime Anciennite { get; set; }
        public Restaurant Restaurant { get; set; }
        public virtual ICollection<Activite> Activites { get; set; }
        public virtual ICollection<TransportSite> TransportSites { get; set; }
    }
}