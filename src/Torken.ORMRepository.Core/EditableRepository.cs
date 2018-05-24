namespace MyRepository.Infrastructure
{
    public class EditableRepository : ReadOnlyRepository, IEditableRepository
    {
        private readonly IEditableSource _editableSource;

        public EditableRepository(IEditableSource editableSource)
            : base(editableSource)
        {
            _editableSource = editableSource;
        }

        public void Add<T>(T entity) where T : class
        {
            _editableSource.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _editableSource.Delete(entity);
        }
    }
}