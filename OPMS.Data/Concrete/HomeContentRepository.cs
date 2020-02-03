using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    public class HomeContentRepository:Repository<HomeContent>,IHomeContentRepository
    {
        public HomeContentRepository(ContextDb context):base(context)
        {

        }
    }
}
