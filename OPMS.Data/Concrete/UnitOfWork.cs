using OPMS.Data.Context;
using OPMS.Data.Interfaces;

namespace OPMS.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public ContextDb Context { get; }
        public UnitOfWork()
        {
            Context = new ContextDb();
        }

        public IPageRepository PageRepository => new PageRepository(Context);

        public IBlogPostRepository BlogPostRepository => new BlogPostRepository(Context);

        public ITagRepository TagRepository
        {
            get { return new TagReposiitory(Context); }
        }
        public ISidebarRepository SidebarRepository => new SidebarRepository(Context);
        public IMenuRepository MenuRepository => new MenuRepository(Context);
        public ISiteSettingsRepository SiteSettingsRepository => new SiteSettingRepository(Context);
        public IContactRepository ContactRepository => new ContactRepository(Context);

        public IUserRepository UserRepository => new UserRepository(Context);

        public IRolesRepository RolesRepository => new RolesRepository(Context);

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
