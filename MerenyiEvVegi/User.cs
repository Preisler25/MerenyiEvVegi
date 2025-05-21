namespace MerenyiEvVegi;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User()
    {
        this.Id = -1;
        this.Name = "";
        this.Email = "";
        this.Password = "";
    }

    public User(string name, string password)
    {
        this.Id = -1;
        this.Name = name;
        this.Email = "";
        this.Password = password;
    }
    
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