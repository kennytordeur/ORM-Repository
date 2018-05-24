namespace MyRepository.Infrastructure
{
    public interface IEditableSource : IReadOnlySource
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void SaveChanges();
    }
}