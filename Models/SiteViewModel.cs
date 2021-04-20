using System.Collections.Generic;
using TouristiqueDbContext.models;

namespace TouristiqueMvc.Models
{
    public class SiteViewModel
    {
        public List<Site> Sites { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public Site Site { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}