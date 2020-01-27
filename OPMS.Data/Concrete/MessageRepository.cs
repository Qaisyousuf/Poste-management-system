using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;
using System.Data.Entity;
using System.Linq;

namespace OPMS.Data.Concrete
{
    public class MessageRepository:Repository<MessageContainer>,IMessageRepository
    {
        public MessageRepository(ContextDb context):base(context)
        {

        }

       
    }
}
