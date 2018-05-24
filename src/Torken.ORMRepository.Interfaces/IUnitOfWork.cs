namespace MyRepository.Infrastructure
{
    using System;

    public interface IUnitOfWork
    {
        IDisposable BeginTransaction();

        void Commit();
    }
}