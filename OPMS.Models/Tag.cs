using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
