namespace OPMS.Models
{
    public class ContactInfo:EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string PlaceName { get; set; }
        public string PlaceAddress { get; set; }
        public string PlaceContactNumber { get; set; }
        public string WebSite { get; set; }
        public string PostalCode { get; set; }
        public string GoogleMap { get; set; }


    }
}
