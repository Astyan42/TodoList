using System;
using System.Collections.Generic;
using System.Linq;
using Data.Configuration;
using DomainObject.Models.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DomainObject.Interfaces.Data.Abstract
{
    public abstract class AbstractRepository<T>: IAbstractRepository<T> where T:Entity
    {

        protected readonly TodoListContext context;
        protected readonly DbSet<T> persistentCollection;

        public AbstractRepository(TodoListContext context)
        {
            this.context = context;
            var property = typeof(TodoListContext).GetProperties().SingleOrDefault(x => x.PropertyType == typeof(DbSet<T>));
            if (property == null || !property.CanRead)
            {
                throw new ArgumentException("Entity " + typeof(T).Name + " does not exist in the current database context.");
            }

            this.persistentCollection = (DbSet<T>)property.GetValue(context, null);
        }

        public virtual T Create(T item)
        {
            item.CreationDate = DateTime.UtcNow;
            item.ModificationDate = DateTime.UtcNow;
            item.Id = Guid.NewGuid();

            var entityEntry = this.persistentCollection.Add(item);
            this.context.SaveChanges();

            return item;
        }

        public virtual T Retrieve(Guid id)
        {
            var item = this.persistentCollection.SingleOrDefault(x => x.Id.Equals(id));
            return item;
        }

        public virtual IEnumerable<T> Retrieve()
        {
            return this.persistentCollection.ToList();
        }

        public virtual IEnumerable<T> RetrieveModifiedAfter(DateTime limit)
        {
            var entities = this.persistentCollection.Where(x => x.ModificationDate > limit);
            return entities;
        }

        public virtual T Update(T item)
        {
            item.ModificationDate = DateTime.UtcNow;
            this.persistentCollection.Update(item);
            this.context.SaveChanges();
            return item;
        }

        public virtual bool Delete(Guid itemId)
        {
            var entity = this.persistentCollection.SingleOrDefault(x => x.Id.Equals(itemId));
            if (entity != null)
            {
                this.persistentCollection.Remove(entity);
                this.context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
