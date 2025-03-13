
    internal class Student : Str, ILearn

    {

    private string name;
    private Type.type type;
    private DoWork doWork;
    public Student() { }
    public Student(string name, Type.type type, DoWork doWork) {
        this.name = name;
        this.type = type;
        this.doWork = doWork;
    }

    public void Learn()
    {
        Console.WriteLine("Мы учимся");
    }

    
    
}

