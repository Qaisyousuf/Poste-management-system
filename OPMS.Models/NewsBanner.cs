namespace OPMS.Models
{
    public class NewsBanner:EntityBase
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string ImageUrl { get; set; }

        public string ButtonText { get; set; }

        public string ButtonUrl { get; set; }

        public string Content { get; set; }
    }
}
