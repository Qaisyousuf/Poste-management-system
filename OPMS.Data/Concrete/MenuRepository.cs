using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    class MenuRepository:Repository<Menu>,IMenuRepository
    {
        public MenuRepository(ContextDb context):base(context)
        {

        }
    }
}
