using OPMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class AboutPageViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Slug { get; set; }


        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }


        [Required]
        [Display(Name = "Banner Image")]
        public string BannerImage { get; set; }


        [Required]
        [Display(Name = "Sub Title")]
        public string SubTitle { get; set; }


        [Required]
        [Display(Name = "Button Url")]
        public string ButtonUrl { get; set; }
        [AllowHtml]
        [Required]
        public string Content { get; set; }


        [Display(Name = "Meta Data")]
        public bool IsAboutMetaDataOn { get; set; }


        [Display(Name = "Meta Keywords")]
        public string MetaKeywordseAbout { get; set; }


        [Display(Name = "Meta Description")]
        public string MetaDescriptionAbout { get; set; }

        [Display(Name = "Search Engine")]
        public bool IsVisibleToSearchEngineAbout { get; set; }



        [Display(Name = "Section")]
        public int SectoinId { get; set; }
        [ForeignKey("SectoinId")]
        public AboutSection AboutSection { get; set; }

        [Display(Name = "Short Section")]
        public int ShortSectionId { get; set; }
        [ForeignKey("ShortSectionId")]
        public AboutShortSection AboutShortSection { get; set; }
    }
}
