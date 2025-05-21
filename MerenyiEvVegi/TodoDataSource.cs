using System.IO;

namespace MerenyiEvVegi;

public class TodoDataSource
{
    public static List<Todo> todos = new List<Todo>();
    private static string filename = "todos.txt";

    public static void AddTodo(Todo todo)
    {
        todos.Add(todo);
    }

    public static void LoadTodos()
    {
        foreach (string line in FileService.LoadFromFile(filename))
        { 
            todos.Add(Todo.FromString(line));
        }
    }

    public static void SaveTodos()
    {
        File.WriteAllLines(filename, todos.Select(t => t.ToString()));
    }
    
} 


