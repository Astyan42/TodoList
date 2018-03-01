using System;
using Business.Abstract;
using DomainObject;
using DomainObject.Interfaces.Business;
using DomainObject.Interfaces.Data;
using Microsoft.Extensions.Logging;

namespace Business.Handlers
{
    public class TodoItemHandler : AbstractHandler<TodoItem, ITodoItemRepository>, ITodoItemHandler
    {
        public TodoItemHandler(ITodoItemRepository repository, ILogger<TodoItemHandler> logger) : base(repository, logger)
        {
        }

        public override TodoItem Create(TodoItem item)
        {
            if (item.DueDate < DateTime.Now) {
                _logger.LogWarning("You cannot create items which expired due dates");
                return null;
            }
            return base.Create(item);
        }
    }
}
