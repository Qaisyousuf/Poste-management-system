using OPMS.Models;
using System.Data.Entity.ModelConfiguration;

namespace OPMS.Data.FluentAPI
{
    class SiteSettingsMapping:EntityTypeConfiguration<SiteSettings>
    {
        public SiteSettingsMapping()
        {
            Property(s => s.SiteName)
                .IsRequired();
            Property(i => i.IsRegister)       
                .IsRequired();
            Property(so => so.SiteOwner)           
                .IsRequired();
        }
    }
}
