using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Models
{
    public class SWorkerProfile:EntityBase
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public string FullName { get; set; }

        public string JobTitle { get; set; }

        public string Content { get; set; }


    }
}
