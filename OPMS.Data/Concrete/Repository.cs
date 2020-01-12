using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace OPMS.Data.Concrete
{
    public class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected ContextDb _context;

        public Repository(ContextDb context)
        {
           _context = context;
        }
        public void Add(TModel entity)
        {
                _context.Set<TModel>().Add(entity);
        }

        public IQueryable<TModel> GetAll()
        {
            var data = _context.Set<TModel>().AsQueryable();
            return data;
        }

        public TModel GetById(object id)
        {
            return _context.Set<TModel>().Find(id);
        }

        public void Remove(TModel entity)
        {
            _context.Set<TModel>().Remove(entity);
        }

        public void RemoveById(object id)
        {
            TModel model = GetById(id);
            if (model != null)
                Remove(model);
        }

        public void Update(TModel entity)
        {
            _context.Entry(entity).State =EntityState.Modified;
        }
    }
}
