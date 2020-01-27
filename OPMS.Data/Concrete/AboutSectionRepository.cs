using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    public class AboutSectionRepository:Repository<AboutSection>,IAboutSectionRepository
    {
        public AboutSectionRepository(ContextDb context):base(context)
        {

        }
    }
}
