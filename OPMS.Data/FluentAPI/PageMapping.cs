using OPMS.Models;
using System.Data.Entity.ModelConfiguration;

namespace OPMS.Data.FluentAPI
{
    class PageMapping:EntityTypeConfiguration<Page>
    {
        public PageMapping()
        {
            Property(t => t.Title)
                .HasColumnName("Page Title")
                .IsRequired();
            Property(s => s.SidebarId)
                .HasColumnName("Sidebar Id");
        }
    }
}
