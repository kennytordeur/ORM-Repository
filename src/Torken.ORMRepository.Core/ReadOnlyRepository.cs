namespace Torken.ORMRepository.Core
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Torken.ORMRepository.Interfaces;

    public class ReadOnlyRepository : IReadOnlyRepository
    {
        protected readonly IReadOnlySource _readOnlySource;

        public ReadOnlyRepository(IReadOnlySource readOnlySource)
        {
            _readOnlySource = readOnlySource;
        }

        public virtual IQueryable<T> All<T>(params Expression<Func<T, object>>[] propertiesToInclude) where T : class
        {
            return _readOnlySource.GetSet<T>(propertiesToInclude);
        }

        public virtual IQueryable<T> All<T>(Expression<Func<T, bool>> condition, params Expression<System.Func<T, object>>[] propertiesToInclude) where T : class
        {
            return All<T>(propertiesToInclude).Where(condition);
        }

        public virtual T SingleOrDefault<T>(Expression<Func<T, bool>> condition, params Expression<System.Func<T, object>>[] propertiesToInclude) where T : class
        {
            return All<T>(condition, propertiesToInclude).SingleOrDefault();
        }

        public virtual TProjection SingleOrDefault<T, TProjection>(Expression<Func<T, bool>> condition, Expression<Func<T, TProjection>> projection) where T: class
        {
            return All<T>(condition).Select(projection).SingleOrDefault();
        }

        public virtual bool Any<T>(Expression<Func<T, bool>> condition) where T : class
        {
            return All<T>().Any(condition);
        }
    }
}