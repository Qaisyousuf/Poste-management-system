using OPMS.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
   public class AboutPageViewModel:BaseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Slug { get; set; }
        public string MainTitle { get; set; }

        public string BannerImage { get; set; }

        public string SubTitle { get; set; }

        public string ButtonUrl { get; set; }
        [AllowHtml]
        public string Content { get; set; }

        public bool IsAboutMetaDataOn { get; set; }

        public string MetaKeywordseAbout { get; set; }

        public string MetaDescriptionAbout { get; set; }

        public bool IsVisibleToSearchEngineAbout { get; set; }


        public int SectoinId { get; set; }
        [ForeignKey("SectoinId")]
        public AboutSection AboutSection { get; set; }


        public int ShortSectionId { get; set; }
        [ForeignKey("ShortSectionId")]
        public AboutShortSection AboutShortSection { get; set; }
    }
}
