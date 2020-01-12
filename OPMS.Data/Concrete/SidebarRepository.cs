using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    public class SidebarRepository:Repository<Sidebar>,ISidebarRepository
    {
        public SidebarRepository(ContextDb context):base(context)
        {

        }
    }
}
