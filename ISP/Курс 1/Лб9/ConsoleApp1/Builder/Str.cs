
    internal class Str
    {

    protected string name = String.Empty;
    protected Type.type type;
    protected DoWork? DoWork;

    public Str() { }
    public Str(string name, Type.type type, DoWork doWork) {

        this.name = name;
        this.type = type;
        this.DoWork = doWork;
    }
    }

