using System.IO;

namespace MerenyiEvVegi;

public class UserDataSource
{
    public static List<User> users = new List<User>();

    public static void AddUser(User user)
    {
        users.Add(user);
    }

    public static void LoadUsers(string fileName)
    {
        foreach (string line in FileService.LoadFromFile(fileName))
        {
            users.Add(User.FromString(line));
        }
    }

    public static void SaveUsers(string fileName)
    {
        File.WriteAllLines(fileName, users.Select(u => u.ToString()));
    }
}