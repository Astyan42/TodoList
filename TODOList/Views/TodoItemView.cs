using System;
using DomainObject;
using Service.Views.Abstract;

namespace Service.Views
{
    public class TodoItemView:AbstractView<TodoItem>
    {
        public TodoItemView(TodoItem todoItem):base(todoItem)
        {
        }

        public string Content { get; set; }
        public DateTime DueDate { get; set; }
        public bool Checked { get; set; }
        public string Priority { get; set; }
    }
}
