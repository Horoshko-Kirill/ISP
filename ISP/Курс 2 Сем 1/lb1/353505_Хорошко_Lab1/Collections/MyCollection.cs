using System.Text.Json.Serialization.Metadata;

public class MyCustomException : Exception
{
    public MyCustomException()
    {
    }

    public MyCustomException(string message) : base(message)
    {
    }
}
public class Node<T>
{
    private T Data;
    public Node<T>? Next;
    public Node<T>? Previous;
    public Node(T data)
    {
        Data = data;
    }
    public T Value
    {
        get { return Data; }
        set { Data = value; }
    }
}



public class MyCustomCollection<T> : ICustomCollection<T>
{
    Node<T>? First;
    Node<T>? Cur;
    Node<T>? Last;

    int count = 0;

    public void Add(T item)
    {
        if (First == null)
        {
            First = new Node<T>(item);
            Last = First;
            Cur = First;
        }
        else
        {
            Last.Next = new Node<T>(item);
            Last.Next.Previous = Last;
            Last = Last.Next;
        }

        count++;
    }


    public int Count
    {
        get { return count; }
    }

    public void Reset()
    {
        Cur = First;
    }

    public void Next()
    {
        if (Cur != Last)
        {
            Cur = Cur.Next;
        }
    }

    public T Current()
    {
        try
        {
            if (count == 0)
                throw new MyCustomException("index out of range");

        }
        catch (MyCustomException ex)
        {
            Console.WriteLine("User exeption: " + ex.Message);
            Environment.Exit(1);
        }
        return Cur.Value;
    }

    public T this[int index]
    {
        get 
        {
            try
            {
                if (index < count)
                {
                    Cur = First;
                    for (int i = 1; i <= index; i++)
                    {
                        Cur = Cur.Next;
                    }
                }
                else
                {
                    throw new MyCustomException("index out of range");
                }
            }
            catch (MyCustomException ex)
            {
                Console.WriteLine("User exeption " + ex.Message);
                Environment.Exit(1);
            }
            return Cur.Value;
        }
        set 
        {

            try
            {
                if (index < count)
                {
                    Cur = First;
                    for (int i = 1; i <= index; i++)
                    {
                        Cur = Cur.Next;
                    }
                }
                else
                {
                    throw new MyCustomException("index out of range");
                }
            }
            catch (MyCustomException ex)
            {
                Console.WriteLine("User exeption " + ex.Message);
                Environment.Exit(1);
            }

            Cur.Value = value;
        }
    }

    public T RemoveCurrent()
    {
        try
        {
            if (count == 0)
                throw new MyCustomException("index out of range");

        }
        catch (MyCustomException ex)
        {
            Console.WriteLine("User exeption: " + ex.Message);
            Environment.Exit(1);
        }
        if (Cur == First)
        {
            T buf = Cur.Value;
            if (count > 1)
            {
                First = First.Next;
                Cur = First;
                First.Previous = null;
            }
            else
            {
                First = null;
                Cur = null;
            }
            count--;
            return buf;
        }
        else
        { 
            T buf = Cur.Value;
            if (Cur != Last)
            {
                Cur.Previous.Next = Cur.Next;
                Cur.Next.Previous = Cur.Previous;
            }
            else
            {
                Cur.Previous.Next = null;
            }
            count--;
            return buf;
        }
        
    }

    public void Remove(T item)
    {
        try
        {
            if (count == 0)
                throw new MyCustomException("index out of range");

        }
        catch (MyCustomException ex)
        {
            Console.WriteLine("User exeption: " + ex.Message);
            Environment.Exit(1);
        }
        for (int i = 0; i < count; i++)
        {
            Node<T> buf = First;
            if (item.Equals(buf.Value))
            {
                if (Cur == First)
                {
                    if (count > 1)
                    {
                        First = First.Next;
                        Cur = First;
                        First.Previous = null;
                    }
                    else
                    {
                        First = null;
                        Cur = null;
                    }
                }
                else
                {
                    if (Cur != Last)
                    {
                        Cur.Previous.Next = Cur.Next;
                        Cur.Next.Previous = Cur.Previous;
                    }
                    else
                    {
                        Cur.Previous.Next = null;
                    }
                }
                count--;
            }
            else
            {
                {
                    buf = buf.Next;
                }
            }
        }
    }

}