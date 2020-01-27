using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPMS.Models
{
    public class MessageContainer:EntityBase
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public DateTime SendingDateTime { get; set; }
        public DateTime AppointmentDateTime { get; set; }

    }
}
