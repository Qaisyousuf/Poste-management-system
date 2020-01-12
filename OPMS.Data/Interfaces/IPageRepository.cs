using OPMS.Models;

namespace OPMS.Data.Interfaces
{
    public interface IPageRepository:IRepository<Page>,ISlug
    {
        Page GetPageBySlug(string slug);
    }
}
