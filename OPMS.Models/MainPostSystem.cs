using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Models
{
    public class MainPostSystem:EntityBase
    {
        public string Title { get; set; }

       
        public DateTime SentDateTime { get; set; }

       
        public DateTime PostExpirationDate { get; set; }

      
        public string SendedBy { get; set; }
       
        public bool HasPost { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel Users { get; set; }

        public string Name { get; set; }


        public int PostSystemId { get; set; }
        [ForeignKey("PostSystemId")]
       
        public PostSystem PostSystems { get; set; }


        public int SocialId { get; set; }
        [ForeignKey("SocialId")]
  
        public SocialWorker SocialWorker { get; set; }
    }
}
