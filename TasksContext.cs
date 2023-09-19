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
    }
}
