using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    class AboutRepository : Repository<AboutPage>, IAboutRepository
    {
        public AboutRepository(ContextDb context):base(context)
        {

        }
        public AboutPage GetAboutPageBySlug(string slug)
        {
            return _context.AboutPages.Where(x => x.Slug == slug).FirstOrDefault();
        }

        public bool SlugExists(string slug)
        {
            return _context.AboutPages.Any(x => x.Slug == slug);
        }

        public bool SlugExists(int? id, string slug)
        {
            return _context.AboutPages.Where(x => x.Id != id).Any(x => x.Slug == slug);
        }
    }
}
