using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MyTodo.Api.Models;
using MyTodo.Core.Models.Dto;
using MyTodo.Core.Services;

namespace MyTodo.Api.Controllers;

[ApiController]
public class TodoController : Controller
{
    private readonly ITodoServices _todoServices;

    public TodoController(ITodoServices todoServices)
    {
        _todoServices = todoServices;
    }
    
    [HttpGet]
    [Route("/todos")]
    public IActionResult GetAllTodos()
    {
        try
        {
            return Ok(_todoServices.GetAllTodos());
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
    
    [HttpPost]
    [Route("/todos")]
    public void CreateTodo(CreateTodoRequest createTodoRequest)
    {
        CreateTodoDto createTodoDto = new CreateTodoDto
        {
            Name = createTodoRequest.Name
        };
        
        _todoServices.CreateTodo(createTodoDto);
    }
}