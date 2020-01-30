using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPMS.Models;

namespace OPMS.Data.Interfaces
{
    public interface IContactPageRepository:IRepository<ContactMainPage>,ISlug
    {
        ContactMainPage GetContactPageBySlug(string slug);
    }
}
