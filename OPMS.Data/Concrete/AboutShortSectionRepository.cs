using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    public class AboutShortSectionRepository:Repository<AboutShortSection>,IAboutShortSectionRepository
    {
        public AboutShortSectionRepository(ContextDb context):base(context)
        {

        }
    }
}
