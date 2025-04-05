namespace MyTodo.Core.Models.Dto;

public class GetAllTodosDto
{
    public string Name { get; set; }
    public bool Completed { get; set; }
    public DateTime Created { get; set; }
}