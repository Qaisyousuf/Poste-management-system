using System.Collections.Generic;

namespace OPMS.Models
{
    public class BlogPost:EntityBase
    {
        public BlogPost()
        {
            Tags = new List<Tag>();
        }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public bool BlogPostMetaDataOn { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaOgImage { get; set; }
        public bool IsVisibleToSearchEngine { get; set; }


    }
}
