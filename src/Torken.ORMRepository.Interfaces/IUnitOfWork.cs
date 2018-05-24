namespace Torken.ORMRepository.Interfaces
{
    using System;

    public interface IUnitOfWork
    {
        IDisposable BeginTransaction();

        void Commit();
    }
}