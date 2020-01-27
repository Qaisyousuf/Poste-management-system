using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    public class FloorsRepository:Repository<FloorsAddress>,IFloorsRepository
    {
        public FloorsRepository(ContextDb context):base(context)
        {

        }
    }
}
