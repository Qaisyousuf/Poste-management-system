using OPMS.Models;

namespace OPMS.Data.Interfaces
{
    public interface IBlogPostRepository:IRepository<BlogPost>,ISlug
    {
        BlogPost GetBlogPostByslug(string slug);
        BlogPost GetBlogPostByTag(int id);
    }
}
