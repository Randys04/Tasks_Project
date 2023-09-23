using Microsoft.EntityFrameworkCore;
using tasks_Project.Models;
using Task = tasks_Project.Models.Task;

namespace tasks_Project
{
    public class TasksContext: DbContext
    {
        public DbSet<Task> Tasks { get; set;}
        public DbSet<Category> Categories { get; set;}

        public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Category");
                category.HasKey(p => p.CategoryId);
                category.Property(p => p.Name).IsRequired().HasMaxLength(150);
                category.Property(p => p.Description);
            });
        }
    }
}
