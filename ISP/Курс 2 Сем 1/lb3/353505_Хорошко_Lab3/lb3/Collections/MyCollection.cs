using System.Collections;
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



public class MyCustomCollection<T> : ICustomCollection<T>, IEnumerable<T>
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
        Cur = First;
        for (int i = 0; i < count + 1; i++)
        {
            try
            {

                if (i == count)
                    throw new MyCustomException("item is missing");
            }
            catch (MyCustomException ex)
            {
                Console.WriteLine("User exeption: " + ex.Message);
                Environment.Exit(1);
            }

            if (item.Equals(Cur.Value))
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
                break;
            }
            else
            {
                {
                    Cur = Cur.Next;
                }
            }
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyCustomEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    private class MyCustomEnumerator : IEnumerator<T>
    {
        private MyCustomCollection<T> _collection;
        private int _index;

        public MyCustomEnumerator(MyCustomCollection<T> collection)
        {
            _collection = collection;
            _index = -1;
        }

        public T Current
        {
            get
            {
                return _collection[_index];
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_index < _collection.Count - 1)
            {
                _index++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            _index = -1;
        }

        public void Dispose()
        {
        }
    }

}