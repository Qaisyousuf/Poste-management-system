using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    public class BuildingRepository:Repository<BuildingAddress>,IBuildingRepository
    {
        public BuildingRepository(ContextDb context):base(context)
        {

        }
    }
}
