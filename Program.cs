using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tasks_Project;
using tasks_Project.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("TasksDB"));
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("tasksDBconnection"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbConection", async ( [FromServices] TasksContext dbContext) => { 

    dbContext.Database.EnsureCreated();
    return Results.Ok($"Base de datos en memoria: {dbContext.Database.IsInMemory()}");
});

app.MapGet("api/tasks", async ([FromServices] TasksContext dbContex) =>
{
    //return Results.Ok(dbContex.Tasks.Include(p => p.Category).Where(p => p.TaskPriority == Priority.High));
    return Results.Ok(dbContex.Tasks.Include(p => p.Category));
});

app.MapPost("api/saveTask", async ([FromServices] TasksContext dbContex, [FromBody] tasks_Project.Models.Task task) =>
{
    task.TaskId = Guid.NewGuid();
    task.CreationDate =  DateTime.Now;
    await dbContex.AddAsync(task);

    // confirm that  changes have been saved
    await dbContex.SaveChangesAsync();
    return Results.Ok();
}); 

app.Run();
