using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Models
{
    class ContactMainPage:EntityBase
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public string SubContent { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string GoogleMapAPIUrl { get; set; }
        public string MetaKeywords { get; set; }

    }
}
