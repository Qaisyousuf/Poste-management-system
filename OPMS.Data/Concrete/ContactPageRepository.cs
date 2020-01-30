using OPMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPMS.Data.Interfaces;
using OPMS.Data.Context;

namespace OPMS.Data.Concrete
{
    class ContactPageRepository:Repository<ContactMainPage>,IContactPageRepository
    {
        public ContactPageRepository(ContextDb context):base(context)
        {

        }
        public ContactMainPage GetContactPageBySlug(string slug)
        {
            return _context.ContactPages.Where(x => x.Slug == slug).FirstOrDefault();
        }

        public bool SlugExists(string slug)
        {
            return _context.ContactPages.Any(x => x.Slug == slug);
        }

        public bool SlugExists(int? id, string slug)
        {
            return _context.ContactPages.Where(x => x.Id != id).Any(x => x.Slug == slug);
        }
    }
}
