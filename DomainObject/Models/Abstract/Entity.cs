using System;
namespace DomainObject.Models.Abstract
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime ModificationDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
