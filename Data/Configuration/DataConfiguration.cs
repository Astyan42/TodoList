using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Configuration
{
    public class DataConfiguration: IDesignTimeDbContextFactory<TodoListContext>
    {
        public DataConfiguration()
        {
        }

        public TodoListContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoListContext>();
            optionsBuilder.UseSqlServer("Server=localhost,32777;Database=todoItem;User Id=sa;Password = myComplexPass!;");

            return new TodoListContext(optionsBuilder.Options);
        }
    }
}
