using OPMS.Models;
using System.Data.Entity.ModelConfiguration;

namespace OPMS.Data.FluentAPI
{
    public class SidebarMapping:EntityTypeConfiguration<Sidebar>
    {
        public SidebarMapping()
        {
            Property(s => s.Name)
                .IsRequired();
            Property(c => c.Content)
                .IsRequired();
        }
    }
}
