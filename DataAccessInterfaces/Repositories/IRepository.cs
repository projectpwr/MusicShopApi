using DataAccessInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessInterfaces.Repositories
{
    public interface IRepository
    {

        void Add<T>(T entity) where T : class, IEntity;
        void Update<T>(T entity) where T : class, IEntity;
        void Delete<T>(T entity) where T : class, IEntity;
        void Save();
        T GetById<T>(int Id) where T : class, IEntity;
        IEnumerable<T> GetAll<T>() where T : class, IEntity;
        //IEnumerable<TEntity> GetAll<TEntity>() where TEntity : IEntity;
        //IEnumerable<T> GetBy<T>(Expression<Func<T, bool>> predicate);
        /*IEnumerable<TEntity> GetAll<TEntity>( Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                 string includeProperties = null,
                                                 int? skip = null,
                                                 int? take = null)  where TEntity : class, IEntity;*/

    }
}
