using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Models
{
    public class SWBanner:EntityBase
    {
        public string BTitle { get; set; }

        public string BSubTitle { get; set; }

        public string BContent { get; set; }

        public string BImage { get; set; }

        public string BButton { get; set; }

        public string BButtonUrl { get; set; }

    }
}
