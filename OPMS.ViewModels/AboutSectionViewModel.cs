using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class AboutSectionViewModel:BaseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string MainTitle { get; set; }

        public string SubTitle { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        public string ButtonUrl { get; set; }

        public string UrlImages { get; set; }

        public DateTime PublishDateTime { get; set; }
    }
}
