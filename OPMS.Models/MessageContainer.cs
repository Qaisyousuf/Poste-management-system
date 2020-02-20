using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPMS.Models
{
    public class MessageContainer:EntityBase
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }

    }
}
