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

        [Display(Name = "Sent Time")]
        public DateTime SentDateTime { get; set; }

        [Display(Name = "Expiration Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime PostExpirationDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Expiration Time")]
        public DateTime PostExpirationTime { get; set; }

        [Display(Name = "Sent By")]
        public string SendedBy { get; set; }

        [Display(Name = "Assign Post")]
        public bool HasPost { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel Users { get; set; }

        [Required]
        [Display(Name = "Resident Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Post Type")]
        public int PostSystemId { get; set; }

        [Display(Name = "Post")]
        [ForeignKey("PostSystemId")]
        public PostSystem PostSystems { get; set; }


        [Required]
        [Display(Name = "Sent By")]
        public int SocialId { get; set; }
        [ForeignKey("SocialId")]
        
        public SocialWorker SocialWorker { get; set; }
    }
}
