namespace MyTodo.Api.Models;

public class CreateTodoRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}