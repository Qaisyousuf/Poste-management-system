using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    public class RoomRepository:Repository<Room>,IRoomRepository
    {
        public RoomRepository(ContextDb context):base(context)
        {

        }
    }
}
