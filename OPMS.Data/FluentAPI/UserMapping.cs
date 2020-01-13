using OPMS.Models;
using System.Data.Entity.ModelConfiguration;

namespace OPMS.Data.FluentAPI
{
    class UserMapping:EntityTypeConfiguration<UserModel>
    {
        public UserMapping()
        {
            HasMany(r => r.Roles)
                .WithMany(u => u.Users)
                .Map(cs =>
                {
                    cs.MapLeftKey("UserId");
                    cs.MapRightKey("RoleId");
                    cs.ToTable("UserRoles");
                });
            Property(n => n.UserName)
                .IsRequired();
            Property(p => p.HashPassword)
                .IsRequired();
            Property(mb => mb.PhoneNumber)
                .IsRequired();
            ToTable("Users");
        }
    }
}
