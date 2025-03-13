
internal class Legal : Str, IEat, IChill
{

    private string name;
    private Type.type type;
    private DoWork doWork;

    public Legal() { }
    public Legal(string name, Type.type type, DoWork doWork)
    {
        this.name = name;
        this.type = type;
        this.doWork = doWork;
    }

    public void chill()
    {
        Console.WriteLine(" и чилим");
    }

    public void Eat()
    {
        Console.Write("Мы едим");
    }
}

