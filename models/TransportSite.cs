namespace ClassLibrary1.models
{
    public class TransportSite
    {
        public Site Site { get; set; }
        public Transport Transport { get; set; }
        public int SiteId { get; set; }
        public int TransportId { get; set; }
    }
}