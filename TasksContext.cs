﻿using Microsoft.EntityFrameworkCore;
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
                category.Property(p => p.Weight);
            });

            modelBuilder.Entity<Task>(task => 
            {
                task.ToTable("Task");
                task.HasKey(p => p.TaskId);
                task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
                task.Property(p => p.Title).IsRequired().HasMaxLength(200);
                task.Property(p => p.Description);
                task.Property(p => p.TaskPriority);
                task.Property(p => p.CreationDate);
                task.Ignore(p => p.Summary);

            });
        }
    }
}
