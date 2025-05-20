using System.IO;

namespace MerenyiEvVegi;

public class FileService
{
    public static void SaveInFile(string filename, List<string> lines)
    {
        File.WriteAllLines(filename, lines);
    }
    
    public static List<string> LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            File.Create(filename).Close();
            return new List<string>();
        };
        string[] lines = File.ReadAllLines(filename);
        return new List<string>(lines);
    }
}