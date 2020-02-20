using OPMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class PageViewModel:BaseViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Slug")]
        public string Slug { get; set; }

        [AllowHtml]
        [Display(Name = "Content")]
        [Required]
        public string Content { get; set; }

        [Display(Name = "Meta Data")]
        public bool IsPageMetaDataOn { get; set; }

        [Display(Name = "Meta Keywords")]
        public string MetaKeywordsPage { get; set; }

        [Display(Name = "Meta Description")]
        public string MetaDescriptionPage { get; set; }

        [Display(Name = "Search Engine")]
        public bool IsVisibleToSearchEnginePage { get; set; }

        [Display(Name = "Sidbar Name")]
        public int SidebarId { get; set; }
        [ForeignKey("SidebarId")]
        public Sidebar Sidebars { get; set; }

        [Display(Name ="Banner Name")]
        public int BannerId { get; set; }
        [ForeignKey("BannerId")]
        public HomeBanner HomeBanner { get; set; }

        [Display(Name ="Home Content")]
        public int HomeContentId { get; set; }
        [ForeignKey("HomeContentId")]
        public HomeContent HomeContent { get; set; }
    }
}
