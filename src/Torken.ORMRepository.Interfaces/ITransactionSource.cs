namespace MyRepository.Infrastructure
{
    using System;

    public interface ITransactionSource
    {
        IDisposable BeginTransaction();

        void Commit();
    }
}