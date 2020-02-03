using OPMS.Data.Context;
using OPMS.Models;
using OPMS.Data.Interfaces;

namespace OPMS.Data.Concrete
{
    public class HomeRRepository:Repository<HomeRR>,IHomeRRepository
    {
        public HomeRRepository(ContextDb context):base(context)
        {

        }
    }
}
