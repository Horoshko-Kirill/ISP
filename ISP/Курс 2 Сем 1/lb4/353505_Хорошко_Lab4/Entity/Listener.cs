


public class Listener
{
    private string name;
    private int age;
    private bool vip;


    public string Name
    {
        get { return name; }
    }


    public int Age
    {
        get { return age; }
    }

    public bool Vip
    {
        get { return vip; }
    }

    public Listener(string name, int age, bool vip)
    {
        this.name = name;
        this.age = age;
        this.vip = vip;
    }
}

