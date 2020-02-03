using System.ComponentModel.DataAnnotations.Schema;

namespace OPMS.Models
{
    public class Page : EntityBase
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public bool IsPageMetaDataOn { get; set; }
        public string MetaKeywordse { get; set; }
        public string MetaDescription { get; set; }
        public bool IsVisibleToSearchEngine { get; set; }

        public int SidebarId { get; set; }
        [ForeignKey("SidebarId")]
        public Sidebar Sidebars { get; set; }

        public int BannerId { get; set; }
        [ForeignKey("BannerId")]
        public HomeBanner HomeBanner { get; set; }

        public int HomeContentId { get; set; }
        [ForeignKey("HomeContentId")]
        public HomeContent HomeContent { get; set; }


    }
}
