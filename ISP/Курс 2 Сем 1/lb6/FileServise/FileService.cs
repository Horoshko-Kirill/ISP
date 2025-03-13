


using System.Text.Json;

public class FileService<T> : IFileService<T> where T : class
{
    public IEnumerable<T> ReadFile(string fileName)
    {
        try
        {
            var json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during JSON deserialization: {ex.Message}");
            throw;
        }
    }
    public void SaveData(IEnumerable<T> data, string fileName)
    {
        try
        {
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during JSON serialization: {ex.Message}");
            throw;
        }
    }
}