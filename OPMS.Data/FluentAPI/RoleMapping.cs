using OPMS.Models;
using System.Data.Entity.ModelConfiguration;

namespace OPMS.Data.FluentAPI
{
    public class RoleMapping:EntityTypeConfiguration<RoleModel>
    {
        public RoleMapping()
        {
            Property(r => r.Name)
                .HasColumnName("Role Name")
                .IsRequired();
            ToTable("Roles");
        }
    }
}
