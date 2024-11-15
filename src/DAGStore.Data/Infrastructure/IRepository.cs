using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAGStore.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Interface that implement common methods of objects
        /// </summary>

        bool Add(T entity);

        bool Update(T entity);

        bool Delete(T entity);

        bool Delete(int id);

        bool DeleteMulti(Expression<Func<T, bool>> where);

        T GetSingleByID(int id);

        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);

        IEnumerable<T> GetAll(string[] includes = null);

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        int Count(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}