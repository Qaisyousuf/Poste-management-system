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
        public string ButtonUrl { get; set; }

        [Required]
        public string ButtonText { get; set; }

        [Required]
        public string SubContent { get; set; }

        [AllowHtml]
        public string GoogleMapAPIUrl { get; set; }

        public bool IsSWorkertMetaDataOn { get; set; }

        public string MetaKeywordseSworker { get; set; }

        public string MetaDescriptionSworker { get; set; }

        public bool IsVisibleToSearchEngineSworker { get; set; }


        [Required]
        public int BannerId { get; set; }
        [ForeignKey("BannerId")]
        public SWBanner SWbanners { get; set; }

    }
}
