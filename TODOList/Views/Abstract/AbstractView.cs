using System;
using System.Linq;
using System.Reflection;
using DomainObject.Models.Abstract;

namespace Service.Views.Abstract
{
    public class AbstractView<T> where T:Entity
    {
        public Guid Id { get; set; }

        public AbstractView()
        {
        }

        protected AbstractView(T entity)
        {
            if (entity != null)
            {
                foreach (var propertyInfo in entity.GetType().GetProperties().ToArray())
                {
                    if (this.GetType().GetProperty(propertyInfo.Name) != null)
                    {
                        if (propertyInfo.PropertyType.GetTypeInfo().IsEnum)
                        {
                            var value = propertyInfo.GetValue(entity, null).ToString();

                            this.GetType().GetProperty(propertyInfo.Name)
                                .SetValue(this, value);
                        }
                        else if (this.GetType().GetProperty(propertyInfo.Name).PropertyType == propertyInfo.PropertyType)
                        {
                            this.GetType()
                                .GetProperty(propertyInfo.Name)
                                .SetValue(this, propertyInfo.GetValue(entity, null));
                        }
                    }
                }
            }
        }

        public virtual T Hydrate(T entity)
        {
            if (entity != null)
            {
                foreach (var propertyInfo in this.GetType().GetProperties().ToArray())
                {
                    if (entity.GetType().GetProperty(propertyInfo.Name) != null)
                    {
                        if (entity.GetType().GetProperty(propertyInfo.Name).PropertyType.GetTypeInfo().IsEnum)
                        {
                            var enumType = entity.GetType().GetProperty(propertyInfo.Name).PropertyType;
                            var value = propertyInfo.GetValue(this, null).ToString();
                            if (!Enum.IsDefined(enumType, value))
                            {
                                throw new ArgumentException();
                            }

                            entity.GetType().GetProperty(propertyInfo.Name)
                                .SetValue(entity, Enum.Parse(enumType, value));
                        }
                        else if (entity.GetType().GetProperty(propertyInfo.Name).PropertyType == propertyInfo.PropertyType)
                        {
                            entity.GetType()
                                .GetProperty(propertyInfo.Name)
                                .SetValue(entity, propertyInfo.GetValue(this, null));
                        }
                    }
                }
            }

            return entity;
        }
    }
}
