using OPMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPMS.Data.Interfaces;
using OPMS.Data.Context;

namespace OPMS.Data.Concrete
{
    public class MessagesSendingRepository:Repository<Messages>,IMessagesSendingRepository
    {
        public MessagesSendingRepository(ContextDb context):base(context)
        {

        }

      
    }
}
