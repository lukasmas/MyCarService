﻿using System.Linq.Expressions;

namespace MyCarService.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T? GetById(long id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
