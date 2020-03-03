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
        [Required(ErrorMessage = "Nom d'utilisateur est nécessaire")]
        [Display(Name = "Nom d'utilisateur")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone est requis")]
        [Display(Name = "Numéro de portable")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


       // [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime SentDateTime { get; set; }

        [Display(Name = "Date de rendez-vous")]
       // [DisplayFormat(DataFormatString ="{0:d}")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime AppointmentOrTaskDateTime { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime AppointmentOrTime { get; set; }
        public string SendedBy { get; set; }


        [Display(Name = "SMS BOX")]
        public int MessageContainerId { get; set; }
        [ForeignKey("MessageContainerId")]
        public MessageContainer MessageContainer { get; set; }

        [Display(Name = "Lieu de travail")]
        public int BuildingId { get; set; }
        [ForeignKey("BuildingId")]
        public BuildingAddress Building { get; set; }



        [Display(Name = "SMS envoyé par")]
        public int SocialId { get; set; }
        [ForeignKey("SocialId")]
        public SocialWorker SocialWorker { get; set; }

        [Display(Name = "Users")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel Users { get; set; }
    }
}
