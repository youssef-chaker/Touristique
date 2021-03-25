using System;
using System.Collections.Generic;

namespace ClassLibrary1.models
{
    public class Transport
    {
        public int Id { get; set; }
        public int Num { get; set; }
        public TimeSpan Debut { get; set; }
        public TimeSpan Fin { get; set; }
        public virtual ICollection<TransportHotel> TransportHotels{ get; set; }
        public virtual ICollection<TransportSite> TransportSites{ get; set; }
    }
}