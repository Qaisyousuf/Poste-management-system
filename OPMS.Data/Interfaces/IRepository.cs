using System.Linq;

namespace OPMS.Data.Interfaces
{
    public interface IRepository<TModel> where TModel:class
    {
        void Add(TModel entity);
        void Update(TModel entity);
        IQueryable<TModel> GetAll();
        IQueryable<TModel> GetAll(params string[] navigationProperties);

        TModel GetById(object id);
        void Remove(TModel entity);
        void RemoveById(object id);
    }
}
