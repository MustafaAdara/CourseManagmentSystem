using InnovationTask.Data;
using InnovationTask.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InnovationTask.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DBContext _context;

        public Repository(DBContext context)
        {
            _context = context;
        }


        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);  
        }

    }
}
