using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class ContactInfoVM:BaseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public string PlaceName { get; set; }
        public string PlaceAddress { get; set; }
        public string PlaceContactNumber { get; set; }
        [AllowHtml]
        public string WebSite { get; set; }
        public string PostalCode { get; set; }
        [AllowHtml]
        public string GoogleMap { get; set; }
    }
}
