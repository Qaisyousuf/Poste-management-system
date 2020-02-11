using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class PostSystemVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string SubTitle { get; set; }
        [Required]
        [AllowHtml]
        public string Content { get; set; }
  
        public string PostCreatedBy { get; set; }
    }
}
