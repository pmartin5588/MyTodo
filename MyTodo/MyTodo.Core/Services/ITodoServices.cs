using MyTodo.Core.Domain;
using MyTodo.Core.Models.Dto;

namespace MyTodo.Core.Services;

public interface ITodoServices
{
    public List<Todo> GetAllTodos();
    public void CreateTodo(CreateTodoDto todo);
}