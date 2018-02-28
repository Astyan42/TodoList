using System;
using Business.Abstract;
using DomainObject;
using DomainObject.Interfaces.Business;
using DomainObject.Interfaces.Data;

namespace Business.Handlers
{
    public class TodoItemHandler : AbstractHandler<TodoItem, ITodoItemRepository>, ITodoItemHandler
    {
        public TodoItemHandler(ITodoItemRepository repository) : base(repository)
        {
        }
    }
}
