using OPMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.ViewModels
{
   public class MessagesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }


        public DateTime SentDateTime { get; set; }

        public DateTime AppointmentOrTaskDateTime { get; set; }
       

        public string SendedBy { get; set; }


        [Display(Name ="Users")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel Users { get; set; }


        [Display(Name ="Messags Box")]
        public int MessageContainerId { get; set; }
        [ForeignKey("MessageContainerId")]
        public MessageContainer MessageContainer { get; set; }



        [Display(Name ="Building Address")]
        public int BuildingId { get; set; }
        [ForeignKey("BuildingId")]
        public BuildingAddress Building { get; set; }



        [Display(Name ="Social Worker")]
        public int SocialId { get; set; }
        [ForeignKey("SocialId")]
        public SocialWorker SocialWorker { get; set; }
    }
}
