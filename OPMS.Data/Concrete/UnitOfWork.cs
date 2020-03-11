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

        public ISidebarRepository SidebarRepository => new SidebarRepository(Context);

        public IMenuRepository MenuRepository => new MenuRepository(Context);

        public ISiteSettingsRepository SiteSettingsRepository => new SiteSettingRepository(Context);

        public IContactRepository ContactRepository => new ContactRepository(Context);

        public IUserRepository UserRepository => new UserRepository(Context);

        public IRolesRepository RolesRepository => new RolesRepository(Context);

        public IMessageRepository MessageRepository => new MessageRepository(Context);

        public ISocialWorkerRepository SocialWorkerRepository => new SocialWorkerRepository(Context);

        public IMessagesSendingRepository MessagesSendingRepository => new MessagesSendingRepository(Context);

        public IAboutSectionRepository AboutSectionRepository => new AboutSectionRepository(Context);

        public IAboutShortSectionRepository AboutShortSectionRepository => new AboutShortSectionRepository(Context);

        public IAboutRepository AboutPageRepository => new AboutRepository(Context);

        public IContactPageRepository ContactPageRepository => new ContactPageRepository(Context);

        public IContactDetailsRepository ContactDetailsRepoistory => new ContactDetailsRepository(Context);

        public IContactInfoRepository ContactInfoRepository => new ContactInfoRepository(Context);

        public ISWorkerPageRepository SWorkerPageRepository => new SWorkerPageRepository(Context);

        public ISWBannerRepository SWBaneerRepository => new SWBannerRepository(Context);

        public ISocialProfileRepository SocialProfileRepository => new SocialProfileRepository(Context);

        public IHomeBannerRepository HomeBannerRepository => new HomeBannerRepository(Context);

        public IHomeContentRepository HomeContentRepository => new HomeContentRepository(Context);

        public IHomeRRepository HomeRRepository => new HomeRRepository(Context);

        public INewsInfoRepository NewInfoRepository => new NewsInfoRepository(Context);

        public INewsBannerRepository NewsBannerRepoistory => new NewsBannerRepository(Context);

        public IPostSystemRepository PostSystemRepository => new PostSystemRepository(Context);

        public IMainPostSystemRepository MainPostSystemRepository => new MainPostSystemRepository(Context);

        public IHelpSupportRepository HelpSupportRepository => new HelpSupportRepository(Context);

        public IUserLocationRepository UserLocationRepository => new UserLocationRepository(Context);

        public IAdminActivityRepository AdminActivityRepository => new AdminActivityRepository(Context);

        public IAdminPanelInfoReposiroty AdminPanelInfo => new AdminPanelInfoReposiroty(Context);

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
