using OPMS.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPMS.ViewModels
{
    public class MainPostSystemVM
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Display(Name = "Date de soumission du poste")]
        public DateTime SentDateTime { get; set; }

        [Display(Name = "La date d'expiration du poste")]
        [Required]
        public DateTime PostExpirationDate { get; set; }


        [Display(Name = "poste envoyé par poste")]
        public string SendedBy { get; set; }

        [Display(Name = "affectation de poste")]
        public bool HasPost { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel Users { get; set; }

        [Required]
        [Display(Name = "Nom du résident")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Type de poste")]
        public int PostSystemId { get; set; }
        [ForeignKey("PostSystemId")]
       
        public PostSystem PostSystems { get; set; }


        [Required]
        [Display(Name = "Nom du social worker")]
        public int SocialId { get; set; }
        [ForeignKey("SocialId")]
        
        public SocialWorker SocialWorker { get; set; }
    }
}
