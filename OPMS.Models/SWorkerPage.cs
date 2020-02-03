using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace OPMS.Models
{
    public class SWorkerPage:EntityBase
    {
  
        public string Title { get; set; }

        public string Content { get; set; }

        public string ButtonUrl { get; set; }

        public string ButtonText { get; set; }

        public string SubContent { get; set; }

        public string GoogleMapAPIUrl { get; set; }

        public bool IsSWorkertMetaDataOn { get; set; }

        public string MetaKeywordse { get; set; }

        public string MetaDescription { get; set; }

        public bool IsVisibleToSearchEngine { get; set; }


        public int BannerId { get; set; }
        [ForeignKey("BannerId")]
        public SWBanner SWbanners { get; set; }

    }
}

