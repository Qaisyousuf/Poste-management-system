using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;
using System.Linq;

namespace OPMS.Data.Concrete
{
    public class PageRepository:Repository<Page>,IPageRepository
    {
        public PageRepository(ContextDb context):base(context)
        {

        }

        public Page GetPageBySlug(string slug)
        {
            return _context.Pages.Where(x => x.Slug == slug).SingleOrDefault();
        }

        public bool SlugExists(string slug)
        {
            return _context.Pages.Any(x => x.Slug == slug);
        }

        public bool SlugExists(int? id, string slug)
        {
            return _context.Pages.Where(x => x.Id != id).Any(x => x.Slug == slug);
        }
    }
}
