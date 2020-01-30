using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPMS.Models;
using OPMS.Data.Interfaces;
using OPMS.Data.Context;

namespace OPMS.Data.Concrete
{
    public class ContactDetailsRepository:Repository<ContactDetails>,IContactDetailsRepository
    {
        public ContactDetailsRepository(ContextDb context):base(context)
        {
                
        }
    }
}
