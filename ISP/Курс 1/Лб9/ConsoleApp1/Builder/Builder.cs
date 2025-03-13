
    internal abstract class Builder
    {
    protected string name = String.Empty;
    protected Type.type type;
    protected DoWork? DoWork;
    public Builder SetName(string name)
    {
        this.name = name;
        return this;
    }

    public Builder SetType( Type.type type)
    {
        this.type = type;
        return this;
    }

    public Builder SetWork(DoWork DoWork)
    {
        this.DoWork = DoWork;
        Console.WriteLine("Мы {0} типа {1}", name, type);
        DoWork.dowork();
        return this;
    }

    public abstract Str Build();
}
