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
            List<Category> categorysInit = new List<Category>();
            categorysInit.Add(new Category {
                CategoryId = Guid.Parse("13e9bff2-1e86-45b2-8a62-bb932992c7bd"),
                Name = "Univesrity homeworks to do",
                Weight = 30
            });
            categorysInit.Add(new Category
            {
                CategoryId = Guid.Parse("13e9bff2-1e86-45b2-8a62-bb932992c723"),
                Name = "Personal Activities",
                Weight = 25
            });

            List<Task> tasksInit= new List<Task>();
            tasksInit.Add(new Task
            {
                TaskId = Guid.Parse("13e9bff2-1e86-45b2-8a62-bb932992c675"),
                CategoryId = Guid.Parse("13e9bff2-1e86-45b2-8a62-bb932992c7bd"),
                Title = "IO homewework 1",
                TaskPriority = Priority.Lowest,
                CreationDate = DateTime.Now,
            });
            tasksInit.Add(new Task
            {
                TaskId = Guid.Parse("13e9bff2-1e86-45b2-8a62-bb932992c602"),
                CategoryId = Guid.Parse("13e9bff2-1e86-45b2-8a62-bb932992c723"),
                Title = "Prepare a presentation",
                TaskPriority = Priority.High,
                CreationDate = DateTime.Now,
            });

            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Category");
                category.HasKey(p => p.CategoryId);
                category.Property(p => p.Name).IsRequired().HasMaxLength(150);
                category.Property(p => p.Description).IsRequired(false);
                category.Property(p => p.Weight);
                category.HasData(categorysInit);
            });

            modelBuilder.Entity<Task>(task => 
            {
                task.ToTable("Task");
                task.HasKey(p => p.TaskId);
                task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
                task.Property(p => p.Title).IsRequired().HasMaxLength(200);
                task.Property(p => p.Description).IsRequired(false);
                task.Property(p => p.TaskPriority);
                task.Property(p => p.CreationDate);
                task.Property(p => p.CompletedTask);
                task.Ignore(p => p.Summary);
                task.HasData(tasksInit);
            });
        }
    }
}
