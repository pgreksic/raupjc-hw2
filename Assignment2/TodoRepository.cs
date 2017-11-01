using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // x ?? y => if x is not null , expression returns x. Else it will return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Get(Guid todoId)
        {
            throw new NotImplementedException();
        }

        public TodoItem Add(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid todoId)
        {
            throw new NotImplementedException();
        }

        public TodoItem Update(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            throw new NotImplementedException();
        }

        public List<TodoItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<TodoItem> GetActive()
        {
            throw new NotImplementedException();
        }

        public List<TodoItem> GetCompleted()
        {
            throw new NotImplementedException();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            throw new NotImplementedException();
        }
    }
}
