using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IUserRepository UserRepository => new UserRepository(Context);

        public ISidebarRepository SidebarRepository => new SidebarRepository(Context);

      

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
