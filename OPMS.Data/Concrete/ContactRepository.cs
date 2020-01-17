using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    public  class ContactRepository:Repository<Contact>,IContactRepository
    {
        public ContactRepository(ContextDb context):base(context)
        {

        }
    }
}
