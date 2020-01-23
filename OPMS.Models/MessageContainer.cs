using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Models
{
     public class MessageContainer:EntityBase
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public DateTime SendingDateTime { get; set; }
        public DateTime AppointmentDateTime { get; set; }


        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel Users { get; set; }

        public int SocialId { get; set; }
        [ForeignKey("SocialId")]
        public SocialWorker SocialWorkers { get; set; }

        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public BuildingAddress Address { get; set; }

    }
}
