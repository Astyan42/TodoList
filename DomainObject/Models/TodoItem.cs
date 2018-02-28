using System;
using DomainObject.Models.Abstract;

namespace DomainObject
{
    public class TodoItem:Entity
    {
        public string Content { get; set; }
        public DateTime DueDate { get; set; }
        public bool Checked { get; set; }
        public Priority Priority { get; set; }
    }
}
