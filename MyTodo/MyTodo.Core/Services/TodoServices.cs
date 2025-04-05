using MyTodo.Core.Domain;
using MyTodo.Core.Models.Dto;
using MyTodo.Core.Repository;

namespace MyTodo.Core.Services;

public class TodoServices : ITodoServices
{
    private readonly ITodoRepository _todoRepository;

    public TodoServices(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }
    public List<Todo> GetAllTodos()
    {
        return _todoRepository.GetAllTodos();
    }

    public void CreateTodo(CreateTodoDto todo)
    {
        Todo domainTodo = new Todo
        {
           Id = Guid.NewGuid(),
           Name = todo.Name,
           Completed = false,
           Created = DateTime.Now,
        };
        _todoRepository.SaveTodo(domainTodo);
    }
}