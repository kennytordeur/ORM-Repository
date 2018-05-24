namespace MyRepository.Infrastructure
{
    public interface IEditableRepository : IReadOnlyRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;
    }
}