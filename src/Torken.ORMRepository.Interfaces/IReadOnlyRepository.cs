namespace Torken.ORMRepository.Interfaces
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IReadOnlyRepository
    {
        IQueryable<T> All<T>(params Expression<Func<T, object>>[] propertiesToInclude) where T : class;

        IQueryable<T> All<T>(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] propertiesToInclude) where T : class;

        T SingleOrDefault<T>(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] propertiesToInclude) where T : class;
                
        TProjection SingleOrDefault<T, TProjection>(Expression<Func<T, bool>> condition, Expression<Func<T, TProjection>> projection) where T : class;

        bool Any<T>(Expression<Func<T, bool>> condition) where T : class;
    }
}