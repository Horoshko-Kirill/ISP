
internal class LegalBuilder : Builder
{

    protected string name = String.Empty;
    protected Type.type type;
    protected DoWork? DoWork;

    public override Str Build()
    {
        Legal legal = new Legal(name, type, DoWork);
        Console.WriteLine("А еще мы студенты");
        legal.Eat();
        legal.chill();
        Console.WriteLine("-------------------");

        return legal;
    }
}

