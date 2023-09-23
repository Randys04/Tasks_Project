using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tasks_Project;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("TasksDB"));
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("tasksDBconnection"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbConection", async ( [FromServices] TasksContext dbContext) => { 

    dbContext.Database.EnsureCreated();
    return Results.Ok($"Base de datos en memoria: {dbContext.Database.IsInMemory()}");
});

app.Run();
