using OPMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Collections.Generic;

namespace OPMS.ViewModels
{
    public class SWorkerPageVM:BaseViewModel
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

        [AllowHtml]
        [Display(Name = "Map API")]
        public string GoogleMapAPIUrl { get; set; }

        [Display(Name = "Meta Data On")]
        public bool IsSWorkertMetaDataOn { get; set; }

        [Display(Name = "Meta Keywords")]
        public string MetaKeywordseSworker { get; set; }

        [Display(Name = "Meta Description")]
        public string MetaDescriptionSworker { get; set; }


        [Display(Name = "Search Engine On")]
        public bool IsVisibleToSearchEngineSworker { get; set; }


        [Required]
        [Display(Name = "Banner")]
        public int BannerId { get; set; }
        [ForeignKey("BannerId")]
        public SWBanner SWbanners { get; set; }

    }
}
