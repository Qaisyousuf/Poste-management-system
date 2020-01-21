using OPMS.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class BlogPostViewModel:BaseViewModel
    {
        public BlogPostViewModel()
        {
            Tags = new List<Tag>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre de l'article de blog est obligatoire")]
        [Display(Name = "Titre de l'article de blog")]
        public string Title { get; set; }

        [Display(Name = "Limace")]
        public string Slug { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Le contenu du billet de blog est requis")]
        [Display(Name = "Contenu du billet de blog")]
        public string Content { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public int[] TagIds { get; set; }

        public List<string> TagNames { get; set; }

        [Display(Name = "Meta Data On")]
        public bool BlogPostMetaDataOn { get; set; }


        //public string MetaKeywords { get; set; }

        [Display(Name = "Meta Description")]
        public string MetaDescription { get; set; }


        //public string MetaOgImage { get; set; }


        //public bool IsVisibleToSearchEngine { get; set; }
    }

}
