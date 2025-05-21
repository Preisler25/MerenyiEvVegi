using System.IO;

namespace MerenyiEvVegi;

public class UserDataSource
{
    public static List<User> users = new List<User>();
    private static string filename = "users.txt";

    public static void AddUser(User user)
    {
        users.Add(user);
    }

    public static void LoadUsers()
    {
        foreach (string line in FileService.LoadFromFile(filename))
        {
            users.Add(User.FromString(line));
        }
    }

    public static void SaveUsers()
    {
        File.WriteAllLines(filename, users.Select(u => u.ToString()));
    }
}