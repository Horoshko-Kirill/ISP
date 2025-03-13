


public class Journal
{
    MyCustomCollection<string> Event = new MyCustomCollection<string>();

    public void LogEvent(string NameOfClass, string NameOfEntity)
    {
        string buf = "Изменен класс " + NameOfClass + " Имя сущности " + NameOfEntity;
        Event.Add(buf);
    }

    public void ExEvent()
    {
        foreach (var i in Event)
        {
            Console.WriteLine(i);
        }
    }
}