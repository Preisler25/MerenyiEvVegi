namespace MerenyiEvVegi;

public class User
{
    private int Id { get; set; }
    private string Name { get; set; }
    private string Email { get; set; }
    private string Password { get; set; }
    
    public User(int id, string name, string email, string password)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
    }
    
    public override string ToString()
    {
        return $"{Id},{Name},{Email},{Password}";
    }

    public static User FromString(string userData)
    {
        var parts = userData.Split(",");
        int userId;
        if (!int.TryParse(parts[0], out userId))
            throw new FormatException("Invalid user id");
        return new User(userId, parts[1], parts[2], parts[3]);
    }
}