using System.ComponentModel.DataAnnotations.Schema;

namespace OPMS.Models
{
    public class Page : EntityBase
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public bool IsPageMetaDataOn { get; set; }
        public bool IsVisibleToSearchEngine { get; set; }

        public int SidebarId { get; set; }

        [ForeignKey("SidebarId")]
        public Sidebar Sidebars { get; set; }


    }
}
