namespace MyRepository.Infrastructure
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IReadOnlySource
    {
        IQueryable<T> GetSet<T>(params Expression<Func<T, object>>[] propertiesToInclude) where T : class;
    }
}