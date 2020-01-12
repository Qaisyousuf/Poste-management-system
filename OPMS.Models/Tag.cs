using System.Collections.Generic;

namespace OPMS.Models
{
    public class Tag:EntityBase
    {
        public Tag()
        {
            BlogPosts = new List<BlogPost>();
        }
        public string Name { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
