using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    public class SocialWorkerRepository:Repository<SocialWorker>,ISocialWorkerRepository
    {
        public SocialWorkerRepository(ContextDb context):base(context)
        {

        }
    }
}
