using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Models
{
    public class HomeContent:EntityBase
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public string SubContent { get; set; }
        public string ButtonText { get; set; }
        public string ButtonUrl { get; set; }
        public string ImageUrl { get; set; }

    }
}
