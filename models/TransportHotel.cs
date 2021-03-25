namespace ClassLibrary1.models
{
    public class TransportHotel
    {
        public Hotel Hotel { get; set; }
        public Transport Transport { get; set; }
        public int HotelId { get; set; }
        public int TransportId { get; set; }
    }
}