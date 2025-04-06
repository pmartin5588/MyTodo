namespace MyTodo.Core.Models.Domain;

public class Todo
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Completed { get; set; }
    public DateTime Created { get; set; }
}