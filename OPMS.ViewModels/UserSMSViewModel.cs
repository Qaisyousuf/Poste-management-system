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
    public class UserSMSViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        [Required]
        [Display(Name = "Resident Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


      
        [DataType(DataType.Date)]
        [Display(Name = "Sent Date")]
        public DateTime SentDateTime { get; set; }


        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }


        [DataType(DataType.Time)]
        [Display(Name = "Appointment Time")]
        public DateTime AppointmentTime { get; set; }

        [Display(Name ="Sent By")]
        public string SendedBy { get; set; }


        [Display(Name = "SMS Type")]
        public int MessageContainerId { get; set; }
        [ForeignKey("MessageContainerId")]
        public MessageContainer MessageContainer { get; set; }

        [Display(Name = "Social Worker")]
        public int SocialId { get; set; }
        [ForeignKey("SocialId")]
        public SocialWorker SocialWorker { get; set; }

        
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel Users { get; set; }
    }
}
