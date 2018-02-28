using System;
using System.Collections.Generic;
using DomainObject.Models.Abstract;

namespace DomainObject.Interfaces.Data
{
    public interface IAbstractRepository<T> where T:Entity
    {
        T Retrieve(Guid id);
        IEnumerable<T> Retrieve();
        IEnumerable<T> RetrieveModifiedAfter(DateTime limit);
        T Create(T item);
        T Update(T item);
        bool Delete(Guid item);
    }
}