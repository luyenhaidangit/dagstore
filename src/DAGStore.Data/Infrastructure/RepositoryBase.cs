using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;

namespace DAGStore.Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Implement common methods of objects
        /// </summary>

        private DAGStoreDbContext dbContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected DAGStoreDbContext DbContext
        {
            get { return dbContext ?? (dbContext = DbFactory.Init()); }
        }

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        public bool Add(T entity)
        {
            try
            {
                dbSet.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        #region Delete

        public bool Delete(T entity)
        {
            try
            {
                dbSet.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = dbSet.Find(id);
                dbSet.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteMulti(Expression<Func<T, bool>> where)
        {
            try
            {
                IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
                foreach (T obj in objects)
                    dbSet.Remove(obj);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        #endregion Delete

        #region Update

        public bool Update(T entity)
        {
            try
            {
                dbSet.Attach(entity);
                dbContext.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion Update

        #region Get

        public T GetSingleByID(int id)
        {
            return dbSet.Find(id);
        }

        public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.FirstOrDefault(expression);
            }
            return dbContext.Set<T>().FirstOrDefault(expression);
        }

        public IEnumerable<T> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }

            return dbContext.Set<T>().AsQueryable();
        }

        public IEnumerable<T> GetByQuery(string query)
        {
            return dbContext.Set<T>().SqlQuery(query);
        }

        public IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(predicate).AsQueryable<T>();
            }

            return dbContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            int skipCount = index * size;
            IQueryable<T> _resetSet;

            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                _resetSet = filter != null ? query.Where<T>(filter).AsQueryable() : query.AsQueryable();
            }
            else
            {
                _resetSet = filter != null ? dbContext.Set<T>().Where<T>(filter).AsQueryable() : dbContext.Set<T>().AsQueryable();
            }

            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        #endregion Get

        #region Count

        public int Count(Expression<Func<T, bool>> where)
        {
            return dbSet.Count(where);
        }

        #endregion Count

        #region Check

        public bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Count<T>(predicate) > 0;
        }

        #endregion Check
    }
}