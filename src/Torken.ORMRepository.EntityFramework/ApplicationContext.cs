using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Torken.ORMRepository.EntityFramework
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System;
    using Torken.ORMRepository.Interfaces;

    public class ApplicationContext<TContext> : DbContext, IReadOnlySource, IEditableSource, ITransactionSource where TContext : ApplicationContext<TContext>
    {
        public ApplicationContext()
             : base()
        {

        }

        public ApplicationContext(DbContextOptions<TContext> options)
            : base(options)
        {
        }

        public IQueryable<T> GetSet<T>(params System.Linq.Expressions.Expression<System.Func<T, object>>[] propertiesToInclude) where T : class
        {
            IQueryable<T> set = Set<T>();

            foreach (var property in propertiesToInclude)
            {
                set = set.Include(property);
            }

            return set;
        }

        public void Add<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            Set<T>().Attach(entity);
            Entry<T>(entity).State = EntityState.Modified;
            base.Update<T>(entity);
        }

        public IDisposable BeginTransaction()
        {
            return Database.BeginTransaction();
        }

        public void Commit()
        {
            Database.CommitTransaction();
        }
    }
}