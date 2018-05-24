namespace MyRepository.Infrastructure
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class ReadOnlyRepository : IReadOnlyRepository
    {
        protected readonly IReadOnlySource _readOnlySource;

        public ReadOnlyRepository(IReadOnlySource readOnlySource)
        {
            _readOnlySource = readOnlySource;
        }

        public IQueryable<T> All<T>(params Expression<Func<T, object>>[] propertiesToInclude) where T : class
        {
            return _readOnlySource.GetSet<T>(propertiesToInclude);
        }

        public IQueryable<T> All<T>(Expression<Func<T, bool>> condition, params Expression<System.Func<T, object>>[] propertiesToInclude) where T : class
        {
            return All<T>(propertiesToInclude).Where(condition);
        }

        public T SingleOrDefault<T>(Expression<Func<T, bool>> condition, params Expression<System.Func<T, object>>[] propertiesToInclude) where T : class
        {
            return All<T>(condition, propertiesToInclude).SingleOrDefault();
        }

        public TProjection SingleOrDefault<T, TProjection>(Expression<Func<T, bool>> condition, Expression<Func<T, TProjection>> projection) where T: class
        {
            return All<T>(condition).Select(projection).SingleOrDefault();
        }

        public bool Any<T>(Expression<Func<T, bool>> condition) where T : class
        {
            return All<T>().Any(condition);
        }
    }
}