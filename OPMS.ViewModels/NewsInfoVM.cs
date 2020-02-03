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
        public string ButtonUrl { get; set; }

        [Required]
        public string ButtonText { get; set; }

        [Required]
        public string SubContent { get; set; }

       
        public DateTime PublishDate { get; set; }
        [AllowHtml]
       
        public string ImageUrl { get; set; }
        [AllowHtml]
        public string GoogleMapAPIUrl { get; set; }

        public bool IsNewInfotMetaDataOn { get; set; }

        public string MetaKeywordseNewsInfo { get; set; }

        public string MetaDescriptionNewsInfo { get; set; }

        public bool IsVisibleToSearchNewsInfo { get; set; }

        public int NewsBannerId { get; set; }
        [ForeignKey("NewsBannerId")]
        public NewsBanner NewsBanners { get; set; }

    }
}
