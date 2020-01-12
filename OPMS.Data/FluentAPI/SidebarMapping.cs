using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using OPMS.Models;

namespace OPMS.Data.FluentAPI
{
    public class SidebarMapping:EntityTypeConfiguration<Sidebar>
    {
        public SidebarMapping()
        {
            Property(s => s.Name)
                .HasColumnName("Sidebar Name")
                .IsRequired();
            Property(c => c.Content)
                .HasColumnName("Content Name")
                .IsRequired();
        }
    }
}
