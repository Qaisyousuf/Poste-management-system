using OPMS.Models;

namespace OPMS.Data.Interfaces
{
    public interface ITagRepository:IRepository<Tag>
    {
        Tag TagsToAdd(int id,int[] TagsId);
    }
}
