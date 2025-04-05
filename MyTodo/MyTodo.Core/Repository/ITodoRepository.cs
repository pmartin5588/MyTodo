using MyTodo.Core.Domain;

namespace MyTodo.Core.Repository;

public interface ITodoRepository
{
    public List<Todo> GetAllTodos();
    public void SaveTodo(Todo todo);
}