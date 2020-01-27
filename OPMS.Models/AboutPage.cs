using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Models
{
    public class AboutPage:EntityBase
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string MainTitle { get; set; }

        public string BannerImage { get; set; }

        public string SubTitle { get; set; }

        public string ButtonUrl { get; set; }

   

        public string Content { get; set; }

        public bool IsAboutMetaDataOn { get; set; }

        public string MetaKeywordse { get; set; }

        public string MetaDescription { get; set; }

        public bool IsVisibleToSearchEngine { get; set; }

        public int SectoinId { get; set; }
        [ForeignKey("SectoinId")]
        public AboutSection AboutSection { get; set; }


        public int ShortSectionId { get; set; }  
        [ForeignKey("ShortSectionId")]
        public AboutShortSection AboutShortSection { get; set; }


    }
}
