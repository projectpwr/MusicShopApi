using System;
using System.Collections.Generic;
using System.Text;
using DataAccessInterfaces.Repositories;
using DataAccessInterfaces.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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

        public IEnumerable<T> GetAll<T>() where T : class, IEntity
        {
            return _context.Set<T>().ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }




        // public virtual TEntity GetById<TEntity>(object id) where TEntity : class, IEntity
        // {
        //     return _context.Set<TEntity>().Find(id);
        // }




    }
}
