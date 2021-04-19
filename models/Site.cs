using System;
using System.Collections.Generic;

namespace TouristiqueDbContext.models
{
    public class Site
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime Anciennite { get; set; }
        public virtual ICollection<NoteSite> Notes { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Activite> Activites { get; set; }
        public virtual ICollection<TransportSite> TransportSites { get; set; }
        public virtual ICollection<SiteComment> Comments { get; set; }
    }
}