﻿using Torken.ORMRepository.Interfaces;

namespace Torken.ORMRepository.Core
{
    public class EditableRepository : ReadOnlyRepository, IEditableRepository
    {
        private readonly IEditableSource _editableSource;

        public EditableRepository(IEditableSource editableSource)
            : base(editableSource)
        {
            _editableSource = editableSource;
        }

        public virtual void Add<T>(T entity) where T : class
        {
            _editableSource.Add(entity);
        }

        public virtual void Delete<T>(T entity) where T : class
        {
            _editableSource.Delete(entity);
        }
    }
}