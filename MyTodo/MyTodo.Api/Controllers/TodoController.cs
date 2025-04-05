using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MyTodo.Api.Models;
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
            _todoServices.GetAllTodos();
            return Ok();
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

    }
}