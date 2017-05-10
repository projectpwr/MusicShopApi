using DataAccessInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessInterfaces.Repositories
{
    interface IRepository<T> where T : IEntity
    {
  
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        T Get(int Id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate);
    }
}
