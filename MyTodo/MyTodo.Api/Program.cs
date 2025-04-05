using MyTodo.Core.Repository;
using MyTodo.Core.Services;
using MyTodo.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITodoServices, TodoServices>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();