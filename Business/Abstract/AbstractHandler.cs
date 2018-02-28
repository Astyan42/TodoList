using System;
using System.Collections.Generic;
using DomainObject.Interfaces.Business;
using DomainObject.Interfaces.Data;
using DomainObject.Models.Abstract;

namespace Business.Abstract
{
    public abstract class AbstractHandler<T, TR>: IAbstractHandler<T> where T:Entity where TR:IAbstractRepository<T>
    {

        protected readonly TR _repository;

        public AbstractHandler(TR repository)
        {
            _repository = repository;
        }

        public virtual T Create(T item)
        {
            return this._repository.Create(item);
        }

        public virtual T Retrieve(Guid id)
        {
            return this._repository.Retrieve(id);
        }

        public virtual IEnumerable<T> Retrieve()
        {
            return this._repository.Retrieve();
        }

        public virtual IEnumerable<T> RetrieveModifiedAfter(DateTime limit)
        {
            return this.RetrieveModifiedAfter(limit);
        }

        public virtual T Update(T item)
        {
            return this._repository.Update(item);
        }

        public virtual bool Delete(Guid item)
        {
            return this._repository.Delete(item);
        }

    }
}
