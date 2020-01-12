using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OPMS.Data.FluentAPI;
using OPMS.Models;

namespace OPMS.Data.Context
{
    public class ContextDb:DbContext
    {
        public ContextDb():base("OPMS")
        {

        }
        public DbSet<Page> Pages { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set;}
        public DbSet<Sidebar> Sidebars { get; set; }
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Menu> Menus { get; set; }

        
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
