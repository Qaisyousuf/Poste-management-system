using OPMS.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace OPMS.ViewModels
{
    public class TagViewModel:BaseViewModel
    {
        public TagViewModel()
        {
            BlogPosts = new List<BlogPost>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage ="Le nom du tag est obligatoire")]
        [Display(Name= "Nom du tag")]
        public string Name { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
