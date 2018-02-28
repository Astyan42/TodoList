using System;
using DomainObject;
using Microsoft.EntityFrameworkCore;

namespace Data.Configuration
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TodoItem>().ToTable("Items");
            modelBuilder.Entity<TodoItem>().HasIndex(x => x.Id).IsUnique();
        }

        public void Initialize()
        {
            this.Database.Migrate();

            // TODO: seeding for a blank database
        }



    }
}
