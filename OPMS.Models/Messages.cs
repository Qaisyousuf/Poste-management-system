using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Models
{
    public class Messages:EntityBase
    {
        public string Title { get; set; }

        public DateTime SentDateTime { get; set; }

        
        public DateTime AppointmentOrTaskDateTime { get; set; }


        public string SendedBy { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel Users { get; set; }


        public int MessageContainerId { get; set; }
        [ForeignKey("MessageContainerId")]
        public MessageContainer MessageContainer { get; set; }



        public int SocialId { get; set; }
        [ForeignKey("SocialId")]
        public SocialWorker SocialWorker { get; set; }
    }
}
