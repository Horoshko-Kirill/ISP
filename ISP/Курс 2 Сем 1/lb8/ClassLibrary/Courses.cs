

public class Courses
{
    public int Id { get; }
    public string Name { get; }

    public int Listeners { get; }

    public Courses(int id, string name, int listeners)
    {
        Id = id;
        Name = name;
        Listeners = listeners;
    }
}
