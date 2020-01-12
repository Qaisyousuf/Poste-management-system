using System;

namespace OPMS.Models
{
    public class Sidebar:EntityBase
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
