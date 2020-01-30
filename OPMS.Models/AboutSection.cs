using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Models
{
    public class AboutSection:EntityBase
    {
        public string Title { get; set; }
        public string MainTitle { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public string ButtonUrl { get; set; }

        public string UrlImages { get; set; }

        public DateTime PublishDateTime { get; set; }

    }
}
