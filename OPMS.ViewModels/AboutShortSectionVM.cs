using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class AboutShortSectionVM:BaseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string MainTitle { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        public string SubContent { get; set; }

        public DateTime PublishDateTime { get; set; }
    }
}
