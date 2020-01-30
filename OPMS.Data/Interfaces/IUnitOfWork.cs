using OPMS.Data.Context;
using System;

namespace OPMS.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ContextDb Context { get; }
        IPageRepository PageRepository { get; }
        IBlogPostRepository BlogPostRepository { get; }
        ITagRepository TagRepository { get; }
        IMenuRepository MenuRepository { get; }
        ISiteSettingsRepository SiteSettingsRepository { get; }
        ISidebarRepository SidebarRepository { get; }
        IContactRepository ContactRepository { get; }
        IUserRepository UserRepository { get;}
        IRolesRepository RolesRepository { get; }
        IMessageRepository MessageRepository { get; }
        ISocialWorkerRepository SocialWorkerRepository { get; }
        IBuildingRepository BuildingRepository { get; }
        IFloorsRepository FloorsRepository { get; }
        IRoomRepository RoomRepository { get; }
        IMessagesSendingRepository MessagesSendingRepository { get; }
        IAboutRepository AboutPageRepository { get; }
        IAboutSectionRepository AboutSectionRepository { get; }
        IAboutShortSectionRepository AboutShortSectionRepository { get; }
        IContactPageRepository ContactPageRepository { get; }
        IContactDetailsRepository ContactDetailsRepoistory { get; }
        IContactInfoRepository ContactInfoRepository { get; }
        void Commit();
    }
}
