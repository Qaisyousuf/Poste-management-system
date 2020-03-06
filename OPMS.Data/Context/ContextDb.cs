using OPMS.Data.FluentAPI;
using OPMS.Models;
using System;
using System.Data.Entity;

namespace OPMS.Data.Context
{
    public class ContextDb:DbContext
    {
        public ContextDb():base("OPMS")
        {
            Configuration.LazyLoadingEnabled = false;
            
        }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Sidebar> Sidebars { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<SiteSettings> SiteSettings { get; set; }
        public DbSet<AboutPage> AboutPages { get; set; }
        public DbSet<AboutSection> AboutSections { get; set; }
        public DbSet<AboutShortSection> AboutShortSections { get; set; }
        public DbSet<ContactMainPage> ContactPages { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<SWorkerPage> SWorkerPage { get; set; }
        public DbSet<SWBanner> SWBanner { get; set; }
        public DbSet<SWorkerProfile> SWorkerProfiles { get; set; }
        public DbSet<HomeBanner> HomeBanners { get; set; }
        public DbSet<HomeRR> HomeRolesResponsibilities { get; set; }
        public DbSet<NewsInfo> NewsInfos { get; set; }
        public DbSet<NewsBanner> NewsBanners { get; set; }
        public DbSet<PostSystem> PostSystems { get; set; }
        public DbSet<MainPostSystem> MainPostSystems { get; set; }
        public DbSet<MessageContainer> MessageContainers { get; set; }
        public DbSet<SocialWorker> SocialWorkers { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<HelpSupport> HelpSupports { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }
        public DbSet<AdminActivity> AdminActivities { get; set; }


        



        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PageMapping());
            modelBuilder.Configurations.Add(new ContactMapping());
            modelBuilder.Configurations.Add(new RoleMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new SidebarMapping());
            modelBuilder.Configurations.Add(new SiteSettingsMapping());
            modelBuilder.Configurations.Add(new MenuMapping());
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
