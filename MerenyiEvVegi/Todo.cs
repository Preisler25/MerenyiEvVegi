namespace MerenyiEvVegi;

public class Todo
{
    public int Id { get; set; }
    public string Task { get; set; }
    public int UserId { get; set; }
    public TodoPrio Priority { get; set; }
    public  TodoState State { get; set; }
    
    public Todo(int id, string task, int userId, TodoPrio priority, TodoState state)
    {
        this.Id = id;
        this.Task = task;
        this.UserId = userId;
        this.Priority = priority;
        this.State = state;
    }

    public override string ToString()
    {
        return $"{Task},{UserId},{Priority},{State},{Id}";
    }
    
    public static Todo FromString(string todoData)
    {
        var parts = todoData.Split(",");
        if (parts.Length != 5)
        {
            Console.WriteLine(parts.Length);
            throw new FormatException("A todo adatainak formátuma nem megfelelő");
        }
        int userId;
        if (!int.TryParse(parts[1], out userId))
            throw new FormatException("A userId nem megfelelő a formátuma");
        int taskId;
        if (!int.TryParse(parts[4], out taskId))
            throw new FormatException("A taskId nem megfelelő a formátuma");
        TodoPrio priority;
        if (!Enum.TryParse(parts[2], out priority))
            throw new FormatException("A prioritynek nem megfelelő a formátuma");
        TodoState state;
        if (!Enum.TryParse(parts[3], out state))
            throw new FormatException("A TodoStatenek nem megfelelő a formátuma");
        return new Todo(taskId, parts[0], userId, priority, state);
    }
}