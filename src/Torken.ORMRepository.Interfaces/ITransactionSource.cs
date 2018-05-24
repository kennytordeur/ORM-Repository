namespace Torken.ORMRepository.Interfaces
{
    using System;

    public interface ITransactionSource
    {
        IDisposable BeginTransaction();

        void Commit();
    }
}