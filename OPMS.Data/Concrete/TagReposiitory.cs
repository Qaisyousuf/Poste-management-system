using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;
using System.Linq;

namespace OPMS.Data.Concrete
{
    public class TagReposiitory:Repository<Tag>,ITagRepository
    {
        public TagReposiitory(ContextDb context):base(context)
        {

        }

        public Tag TagsToAdd(int id, int[] TagsId)
        {
            return _context.Tags.Where(x => TagsId.Contains(x.Id)).FirstOrDefault();
        }
    }
}
