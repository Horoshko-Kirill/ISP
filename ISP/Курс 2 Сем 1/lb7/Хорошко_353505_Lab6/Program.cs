using System.Threading;

class Program
{
    static void Main()
    {

        Integral myIntegral = new Integral();
        Events events = new Events();

        myIntegral.time += events.PrintTime;
        myIntegral.progress += events.PrintProgress;
        myIntegral.result += events.PrintResult;

        /*Thread thread1 = new Thread(() => myIntegral.Square(Thread.CurrentThread.ManagedThreadId));

        Console.WriteLine("1 поток");

        thread1.Start();

        thread1.Join();

        Console.WriteLine("\n2 потока");

        Thread thread2 = new Thread(() => myIntegral.Square(Thread.CurrentThread.ManagedThreadId));
        Thread thread3 = new Thread(() => myIntegral.Square(Thread.CurrentThread.ManagedThreadId));

        thread2.Priority = ThreadPriority.Highest; 
        thread3.Priority = ThreadPriority.Lowest;

        thread3.Start();
        thread2.Start();


        thread2.Join();
        thread3.Join();

        Console.WriteLine("\n5 потоков");

        Thread thread4 = new Thread(() => myIntegral.Square(Thread.CurrentThread.ManagedThreadId));
        Thread thread5 = new Thread(() => myIntegral.Square(Thread.CurrentThread.ManagedThreadId));
        Thread thread6 = new Thread(() => myIntegral.Square(Thread.CurrentThread.ManagedThreadId));
        Thread thread7 = new Thread(() => myIntegral.Square(Thread.CurrentThread.ManagedThreadId));
        Thread thread8 = new Thread(() => myIntegral.Square(Thread.CurrentThread.ManagedThreadId));


        thread4.Priority = ThreadPriority.Highest;
        thread5.Priority = ThreadPriority.Lowest;
        thread6.Priority = ThreadPriority.Highest;
        thread7.Priority = ThreadPriority.Lowest;
        thread8.Priority = ThreadPriority.Highest;

        thread4.Start();
        thread5.Start();
        thread6.Start();
        thread7.Start();
        thread8.Start();


        thread4.Join();
        thread5.Join();
        thread6.Join();
        thread7.Join();
        thread8.Join();

        Console.WriteLine("\n2 потока по очереди");

        Thread thread10 = new Thread(() => myIntegral.SquareOne(Thread.CurrentThread.ManagedThreadId));
        Thread thread11 = new Thread(() => myIntegral.SquareOne(Thread.CurrentThread.ManagedThreadId));

        thread10.Start();
        thread11.Start();


        thread10.Join();
        thread11.Join();*/

        myIntegral.setSemaphore(3);

        Console.WriteLine("\n5 потоков по 3");

        Thread thread12 = new Thread(() => myIntegral.SquareMany(Thread.CurrentThread.ManagedThreadId));
        Thread thread13 = new Thread(() => myIntegral.SquareMany(Thread.CurrentThread.ManagedThreadId));
        Thread thread14 = new Thread(() => myIntegral.SquareMany(Thread.CurrentThread.ManagedThreadId));
        Thread thread15 = new Thread(() => myIntegral.SquareMany(Thread.CurrentThread.ManagedThreadId));
        Thread thread16 = new Thread(() => myIntegral.SquareMany(Thread.CurrentThread.ManagedThreadId));

        thread12.Start();
        thread13.Start();
        thread14.Start();
        thread15.Start();
        thread16.Start();


        thread12.Join();
        thread13.Join();
        thread14.Join();
        thread15.Join();
        thread16.Join();


    }
}