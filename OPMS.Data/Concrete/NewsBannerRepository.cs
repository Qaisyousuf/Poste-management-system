using OPMS.Data.Context;
using OPMS.Models;
using OPMS.Data.Interfaces;

namespace OPMS.Data.Concrete
{
    public class NewsBannerRepository:Repository<NewsBanner>,INewsBannerRepository
    {
        public NewsBannerRepository(ContextDb context):base(context)
        {

        }
    }
}
