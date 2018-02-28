using System;
using Business.Handlers;
using DomainObject.Interfaces.Business;
using DomainObject.Interfaces.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class BusinessExtension
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<ITodoItemHandler,TodoItemHandler>();
            return services;
        }
    }
}
