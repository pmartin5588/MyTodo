using MyTodo.Core.Models.Domain;
using MyTodo.Core.Repository;
using Npgsql;

namespace MyTodo.Infrastructure.Repository;

public class TodoRepository : ITodoRepository
{
    
    string connectionString = "Host=localhost;Port=5432;Username=admin;Password=adminpassword;Database=mydatabase;";
    
    public List<Todo> GetAllTodos()
    {
        using var connection = new NpgsqlConnection(connectionString);
        
        string sql = "SELECT * FROM test_table;";
        
        connection.Open();
        using var command = new NpgsqlCommand(sql,connection);
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
        using var connection = new NpgsqlConnection(connectionString);
        string sql = $"INSERT INTO test_table VALUES (@GUID, @Name, @IsCompleted, @Created);";
        
        try
        {
            connection.Open();
            using var command = new NpgsqlCommand(sql,connection);
            command.Parameters.AddWithValue("@GUID", todo.Id);
            command.Parameters.AddWithValue("@Name", todo.Name);
            command.Parameters.AddWithValue("@IsCompleted", todo.Completed);
            command.Parameters.AddWithValue("@Created", todo.Created);
            command.ExecuteNonQuery();
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}