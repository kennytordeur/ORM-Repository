using Torken.ORMRepository.Interfaces;

namespace Torken.ORMRepository.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IEditableSource _commandSource;

        public UnitOfWork(IEditableSource editableSource)
        {
            _commandSource = editableSource;
        }

        public void Commit()
        {
            _commandSource.SaveChanges();
        }

        public System.IDisposable BeginTransaction()
        {
            return null;    
        }
    }
}