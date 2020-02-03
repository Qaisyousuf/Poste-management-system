using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    public class NewsInfoRepository:Repository<NewsInfo>,INewsInfoRepository
    {
        public NewsInfoRepository(ContextDb context):base(context)
        {

        }
    }
}
