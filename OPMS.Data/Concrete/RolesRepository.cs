using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    public class RolesRepository:Repository<RoleModel>,IRolesRepository
    {
        public RolesRepository(ContextDb context):base(context)
        {

        }
    }
}
