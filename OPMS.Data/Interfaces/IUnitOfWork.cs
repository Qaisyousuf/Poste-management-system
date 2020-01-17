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
       

        void Commit();
    }
}
