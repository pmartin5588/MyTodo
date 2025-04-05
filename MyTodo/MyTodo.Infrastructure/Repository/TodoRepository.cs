using MyTodo.Core.Domain;
using MyTodo.Core.Repository;
using Npgsql;

namespace MyTodo.Infrastructure.Repository;

public class TodoRepository : ITodoRepository
{
    
    string connectionString = "Host=localhost;Port=5432;Username=admin;Password=adminpassword;Database=mydatabase;";
    
    public List<Todo> GetAllTodos()
    {
        using var connection = new NpgsqlConnection(connectionString);
        
        string cmd = "SELECT * FROM test_table;";
        
        connection.Open();
        using var command = new NpgsqlCommand(cmd,connection);
        var reader = command.ExecuteReader();

        List<Todo> result = new List<Todo>();
        while (reader.Read())
        {
            Todo todo = new Todo
            {
                Id = reader.GetGuid(0),
                Name = reader.GetString(1),
                Completed = reader.GetBoolean(2),
                Created = reader.GetDateTime(3),
            };
            result.Add(todo);
        }
        return result;
    }

    public void SaveTodo(Todo todo)
    {
        throw new NotImplementedException();
    }
}