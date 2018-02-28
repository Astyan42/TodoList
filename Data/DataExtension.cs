using System;
using Data.Configuration;
using Data.Repositories;
using DomainObject.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Extensions
{
    public static class DataExtension 
    {
        
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // TODO: Get connection string from a parameter (appsettings file)
            services.AddDbContext<TodoListContext>((DbContextOptionsBuilder obj) => obj.UseSqlServer("Server=db;Database=todoItem;User Id=sa;Password = myComplexPass!;"));
            services.AddScoped<ITodoItemRepository,TodoItemRepository>();
            return services;
        }

        public static IServiceCollection InitializeRepositories(this IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            var context = sp.GetService<TodoListContext>();
            context.Database.Migrate();
            return services;
        }
    }
}
