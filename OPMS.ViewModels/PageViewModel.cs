using OPMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class PageViewModel:BaseViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le titre de la page est requis")]
        [Display(Name = "Titre")]
        public string Title { get; set; }

        [Display(Name = "Limace")]
        public string Slug { get; set; }

        [AllowHtml]
        [Display(Name = "Contenu")]
        [Required(ErrorMessage = "Le contenu de la page est requis")]
        public string Content { get; set; }

        [Display(Name = "Mots-clés Meta")]
        public string MetaKeywords { get; set; }

        [Display(Name = "Meta Description")]
        public string MetaDescription { get; set; }


        [Display(Name = "Page Métadonnées sur")]
        public bool IsPageMetaDataOn { get; set; }

        [Display(Name = "Visible sur le moteur de recherche")]
        public bool IsVisibleToSearchEngine { get; set; }
        [Display(Name = "Barre latérale")]
        public int SidebarId { get; set; }

        [ForeignKey("SidebarId")]
        public Sidebar Sidebars { get; set; }
    }
}
