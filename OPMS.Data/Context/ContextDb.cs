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
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set;}
        public DbSet<Sidebar> Sidebars { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<SiteSettings> SiteSettings { get; set; }

        



        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PageMapping());
            modelBuilder.Configurations.Add(new TagMapping());
            modelBuilder.Configurations.Add(new BlogPostMapping());
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
