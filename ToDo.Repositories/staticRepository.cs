using System.Collections.Generic;
using System.Linq;
using ToDo.Domain;

namespace ToDo.Repository
{
    public class ToDoRepository
    {
        private readonly List<Domain.ToDo> _todos = new List<Domain.ToDo>();
        private int _nextId = 1;

        public Domain.ToDo Create(Domain.ToDo todo)
        {
            todo.Id = _nextId++;
            _todos.Add(todo);
            return todo;
        }

        public Domain.ToDo GetById(int id)
        {
            return _todos.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Domain.ToDo> GetAll()
        {
            return _todos.ToList();
        }

        public void Update(Domain.ToDo updatedTodo)
        {
            var existingTodo = GetById(updatedTodo.Id);
            if (existingTodo != null)
            {
                existingTodo.Task = updatedTodo.Task;
                existingTodo.Date = updatedTodo.Date;
                existingTodo.Done = updatedTodo.Done;
            }
        }

        public void Delete(int id)
        {
            var todoToRemove = GetById(id);
            if (todoToRemove != null)
            {
                _todos.Remove(todoToRemove);
            }
        }
    }
}