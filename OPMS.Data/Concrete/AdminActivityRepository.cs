using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    class AdminActivityRepository:Repository<AdminActivity>,IAdminActivityRepository
    {
        public AdminActivityRepository(ContextDb context):base(context)
        {

        }
    }
}
