using System;
using Data.Configuration;
using DomainObject;
using DomainObject.Interfaces.Data;
using DomainObject.Interfaces.Data.Abstract;

namespace Data.Repositories
{
    public class TodoItemRepository : AbstractRepository<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(TodoListContext context) : base(context)
        {
        }
    }
}
