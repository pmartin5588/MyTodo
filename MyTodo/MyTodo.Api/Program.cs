using MyTodo.Core.Repository;
using MyTodo.Core.Services;
using MyTodo.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITodoServices, TodoServices>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.Run();