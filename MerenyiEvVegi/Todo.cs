namespace MerenyiEvVegi;

public class Todo
{
    private string Task { get; set; }
    private int UserId { get; set; }
    private TodoPrio Priority { get; set; }
    private TodoState State { get; set; }
    
    public Todo(string task, int userId, TodoPrio priority, TodoState state)
    {
        this.Task = task;
        this.UserId = userId;
        this.Priority = priority;
        this.State = state;
    }

    public override string ToString()
    {
        return $"{Task},{UserId},{Priority},{State}";
    }
    
    public static Todo FromString(string todoData)
    {
        var parts = todoData.Split(",");
        if (parts.Length != 4)
            throw new FormatException("A todo adatainak formátuma nem megfelelő");
        int userId;
        if (!int.TryParse(parts[1], out userId))
            throw new FormatException("A userId nem megfelelő a formátuma");
        TodoPrio priority;
        if (!Enum.TryParse(parts[2], out priority))
            throw new FormatException("A prioritynek nem megfelelő a formátuma");
        TodoState state;
        if (!Enum.TryParse(parts[3], out state))
            throw new FormatException("A TodoStatenek nem megfelelő a formátuma");
        return new Todo(parts[0], userId, priority, state);
    }
}