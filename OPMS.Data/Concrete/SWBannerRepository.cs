using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Data.Concrete
{
    public  class SWBannerRepository:Repository<SWBanner>,ISWBannerRepository
    {
        public SWBannerRepository(ContextDb context):base(context)
        {

        }
    }
}
