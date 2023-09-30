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

app.MapPost("api/tasks", async ([FromServices] TasksContext dbContex, [FromBody] tasks_Project.Models.Task task) =>
{
    task.TaskId = Guid.NewGuid();
    task.CreationDate =  DateTime.Now;
    await dbContex.AddAsync(task);

    // confirm that  changes have been saved
    await dbContex.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("api/tasks/{id}", async ([FromServices] TasksContext dbContex, [FromBody] tasks_Project.Models.Task task, [FromRoute] Guid id) =>
{
    var taskUpdate = dbContex.Tasks.Find(id);

    if(taskUpdate != null)
    {
        taskUpdate.CategoryId = task.CategoryId;
        taskUpdate.Title = task.Title;
        taskUpdate.Description = task.Description;
        taskUpdate.TaskPriority = task.TaskPriority;

        await dbContex.SaveChangesAsync();
        return Results.Ok();
    }
    
    return Results.NotFound();
});

app.MapDelete("api/tasks/{id}", async ([FromServices] TasksContext dbContex, [FromRoute] Guid id) =>
{
    var taskDelete = dbContex.Tasks.Find(id);
    if(taskDelete != null)
    {
        dbContex.Remove(taskDelete);

        await dbContex.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.Run();
