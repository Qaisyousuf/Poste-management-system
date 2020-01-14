using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Data.Concrete
{
    class BlogPostRepository:Repository<BlogPost>,IBlogPostRepository
    {
        public BlogPostRepository(ContextDb context):base(context)
        {

        }

        public BlogPost GetBlogPostByslug(string slug)
        {
            return _context.BlogPosts.Where(x => x.Slug == slug).SingleOrDefault();
        }

        public BlogPost GetBlogPostByTag(int id)
        {
            return _context.BlogPosts.Include("Tags").Where(x => x.Id == id).FirstOrDefault();
        }

        public bool SlugExists(string slug)
        {
            return _context.BlogPosts.Any(x => x.Slug == slug);
        }

        public bool SlugExists(int? id, string slug)
        {
            return _context.BlogPosts.Where(x => x.Id != id).Any(x => x.Slug == slug);
        }
    }
}
