using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using OPMS.Models;

namespace OPMS.Data.FluentAPI
{
    public class RoleMapping:EntityTypeConfiguration<RoleModel>
    {
        public RoleMapping()
        {
            Property(r => r.Name)
                .HasColumnName("Role Name")
                .IsRequired();
        }
    }
}
