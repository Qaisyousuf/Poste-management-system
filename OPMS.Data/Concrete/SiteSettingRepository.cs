using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    class SiteSettingRepository:Repository<SiteSettings>,ISiteSettingsRepository
    {
        public SiteSettingRepository(ContextDb context):base(context)
        {

        }
    }
}
