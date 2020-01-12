using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;

namespace OPMS.Data.Concrete
{
    public class TagReposiitory:Repository<Tag>,ITagRepository
    {
        public TagReposiitory(ContextDb context):base(context)
        {

        }
    }
}
