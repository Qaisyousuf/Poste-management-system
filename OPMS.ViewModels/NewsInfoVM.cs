using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using OPMS.Models;

namespace OPMS.ViewModels
{
   public  class NewsInfoVM:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Button Url")]
        public string ButtonUrl { get; set; }

        [Required]
        [Display(Name = "Button Text")]
        public string ButtonText { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "Sub Content")]
        public string SubContent { get; set; }

       
        [Display(Name ="Publish Date")]
        public DateTime PublishDate { get; set; }

        [AllowHtml]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }


        [AllowHtml]
        [Display(Name = "Google API")]
        public string GoogleMapAPIUrl { get; set; }

        [Display(Name = "Meta Data")]
        public bool IsNewInfotMetaDataOn { get; set; }

        [Display(Name = "Meta Keywords")]
        public string MetaKeywordseNewsInfo { get; set; }

        [Display(Name = "Meta Description")]
        public string MetaDescriptionNewsInfo { get; set; }

        [Display(Name = "Search Engine")]
        public bool IsVisibleToSearchNewsInfo { get; set; }

        [Display(Name = "News Banner")]
        public int NewsBannerId { get; set; }
        [ForeignKey("NewsBannerId")]
        public NewsBanner NewsBanners { get; set; }

    }
}
