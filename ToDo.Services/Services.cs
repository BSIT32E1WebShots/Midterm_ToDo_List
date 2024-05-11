using System;
using System.Collections.Generic;
using ToDo.Domain;
using ToDo.Repository;

namespace ToDo.Services
{
    public class ToDoService
    {
        private readonly ToDoRepository _repository;

        public ToDoService(ToDoRepository repository)
        {
            _repository = repository;
        }

        public Domain.ToDo Create(Domain.ToDo todo)
        {
            return _repository.Create(todo);
        }

        public Domain.ToDo GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Domain.ToDo> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(Domain.ToDo updatedTodo)
        {
            _repository.Update(updatedTodo);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}