using DataAccessInterfaces.Entities;
using DataAccessInterfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class Repository : IRepository
    {
        private DbContext _context;

        public Repository( DbContext dbContext )
        {
            _context = dbContext;
        }

        public void Add<T>(T entity) where T : class, IEntity
        {
            _context.Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : class, IEntity
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete<T>(T entity) where T : class, IEntity
        {
            _context.Set<T>().Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public T GetById<T>(int Id) where T : class, IEntity
        {
            return _context.Set<T>().Find(Id);
        }

        public IEnumerable<T> GetAll<T>() where T : class, IEntity
        {
            return _context.Set<T>().ToList();
        }





        // public virtual TEntity GetById<TEntity>(object id) where TEntity : class, IEntity
        // {
        //     return _context.Set<TEntity>().Find(id);
        // }




    }
}
