using System.IO;

namespace MerenyiEvVegi;

public class TodoDataSource
{
    public static List<Todo> todos = new List<Todo>();

    public static void AddTodo(Todo todo)
    {
        todos.Add(todo);
    }

    public static void LoadTodos(string fileName)
    {
        foreach (string line in FileService.LoadFromFile(fileName))
        { 
            todos.Add(Todo.FromString(line));
        }
    }

    public static void SaveTodos(string fileName)
    {
        File.WriteAllLines(fileName, todos.Select(t => t.ToString()));
    }
    
} 


