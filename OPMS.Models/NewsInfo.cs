using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPMS.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPMS.Models
{
    public class NewsInfo:EntityBase
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string ButtonUrl { get; set; }

        public string ButtonText { get; set; }

        public string SubContent { get; set; }

        public DateTime PublishDate { get; set; }

        public string ImageUrl { get; set; }


        public string GoogleMapAPIUrl { get; set; }

        public bool IsNewsInfotMetaDataOn { get; set; }

        public string MetaKeywordse { get; set; }

        public string MetaDescription { get; set; }

        public bool IsVisibleToSearchEngine { get; set; }

        public int NewsBannerId { get; set; }
        [ForeignKey("NewsBannerId")]
        public NewsBanner NewsBanners { get; set; }


    }
}
