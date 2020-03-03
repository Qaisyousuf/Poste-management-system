using System.ComponentModel.DataAnnotations;

namespace OPMS.ViewModels
{
    public class SocialWorkerViewModel
    {
        public int Id { get; set; }


        [Required]
        [Display]
        public string FullName { get; set; }


        [Required]
        [Display(Name = "Job Title")]
        public string Position { get; set; }
    }
}
