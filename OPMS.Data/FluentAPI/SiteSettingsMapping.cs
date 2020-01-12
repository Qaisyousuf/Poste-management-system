using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using OPMS.Models;

namespace OPMS.Data.FluentAPI
{
    class SiteSettingsMapping:EntityTypeConfiguration<SiteSettings>
    {
        public SiteSettingsMapping()
        {
            Property(s => s.SiteName)
                .HasColumnName("Site Name")
                .IsRequired();
            Property(i => i.IsRegister)
                .HasColumnName("Is Site Register")
                .IsRequired();
            Property(sf => sf.SiteFooter)
                .HasColumnName("Site Footer");
            Property(so => so.SiteOwner)
                .HasColumnName("Site Owner")
                .IsRequired();
            Property(gs => gs.GoogleSiteVerification)
                .HasColumnName("Google Site Verification");
            Property(ga => ga.GoogleAds)
                .HasColumnName("Google Ads");
            Property(gn => gn.GoogleAnalytics)
                .HasColumnName("Google Analytics");
            Property(sl => sl.SiteLastUpdated)
                .HasColumnName("site Last Updated");
            Property(sb => sb.UpdateBy)
                .HasColumnName("Updated By");
        }
    }
}
