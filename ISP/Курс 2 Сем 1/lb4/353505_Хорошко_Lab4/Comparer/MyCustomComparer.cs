
public class MyCustomComparer : IComparer<Listener>
{
    public int Compare(Listener a, Listener b)
    {
     
        return string.Compare(a.Name, b.Name);
    }
}
