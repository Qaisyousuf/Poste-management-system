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

        
        
        [Display(Name ="Users")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel Users { get; set; }


        [Display(Name ="Messags Content")]
        public int MessageContainerId { get; set; }
        [ForeignKey("MessageContainerId")]
        public MessageContainer MessageContainer { get; set; }



        [Display(Name ="Building Address")]
        public int BuildingId { get; set; }
        [ForeignKey("BuildingId")]
        public BuildingAddress Building { get; set; }


        [Display(Name = "Room Number")]
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Rooms { get; set; }


        [Display(Name = "Floors Number")]
        public int FloorId { get; set; }
        [ForeignKey("FloorId")]
        public FloorsAddress Florrs { get; set; }


        [Display(Name ="Social Worker")]
        public int SocialId { get; set; }
        [ForeignKey("SocialId")]
        public SocialWorker SocialWorker { get; set; }
    }
}
