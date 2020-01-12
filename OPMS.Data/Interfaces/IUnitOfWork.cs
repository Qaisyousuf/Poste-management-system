using OPMS.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ContextDb Context { get; }
        IPageRepository PageRepository { get; }
        IBlogPostRepository BlogPostRepository { get; }
        ITagRepository TagRepository { get; }
        IUserRepository UserRepository { get; }

        ISidebarRepository SidebarRepository { get; }

        void Commit();
    }
}
