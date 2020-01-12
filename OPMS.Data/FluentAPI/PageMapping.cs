using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using OPMS.Models;

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
