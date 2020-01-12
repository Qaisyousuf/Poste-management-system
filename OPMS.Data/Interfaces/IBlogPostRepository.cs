using OPMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Data.Interfaces
{
    public interface IBlogPostRepository:IRepository<BlogPost>,ISlug
    {
        BlogPost GetBlogPostByslug(string slug);
    }
}
