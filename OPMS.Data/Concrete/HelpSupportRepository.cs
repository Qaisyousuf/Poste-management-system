using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    public class HelpSupportRepository:Repository<HelpSupport>,IHelpSupportRepository
    {
        public HelpSupportRepository(ContextDb context):base(context)
        {

        }
    }
}
