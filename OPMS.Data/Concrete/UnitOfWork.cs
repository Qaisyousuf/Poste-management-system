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

        public IMessageRepository MessageRepository => new MessageRepository(Context);

        public ISocialWorkerRepository SocialWorkerRepository => new SocialWorkerRepository(Context);

        public IBuildingRepository BuildingRepository => new BuildingRepository(Context);

        public IFloorsRepository FloorsRepository => new FloorsRepository(Context);

        public IRoomRepository RoomRepository => new RoomRepository(Context);

        public IMessagesSendingRepository MessagesSendingRepository => new MessagesSendingRepository(Context);

      

        public IAboutSectionRepository AboutSectionRepository => new AboutSectionRepository(Context);

        public IAboutShortSectionRepository AboutShortSectionRepository => new AboutShortSectionRepository(Context);

        public IAboutRepository AboutPageRepository => new AboutRepository(Context);

        public IContactPageRepository ContactPageRepository => new ContactPageRepository(Context);

        public IContactDetailsRepository ContactDetailsRepoistory => new ContactDetailsRepository(Context);

        public IContactInfoRepository ContactInfoRepository => new ContactInfoRepository(Context);

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
