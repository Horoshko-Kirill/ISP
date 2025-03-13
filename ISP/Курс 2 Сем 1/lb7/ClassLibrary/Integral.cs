using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
public class Integral
{

    public event Action<double> result;
    public event Action<long> time;
    public event Action<double, int> progress;

    public void Square(int thread)
    {
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();

        double res = 0;

        for (double x = 0; x < 1;)
        {
            x += 0.00001;
            res += 0.00001 * Math.Sin(x);

            for (int i = 0; i < 100000; i++)
            {
                double a = i * i;
            }

            progress?.Invoke(x, thread);
        }

        stopwatch.Stop();

        long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;


        result?.Invoke(res);

        time?.Invoke(elapsedMilliseconds);
    }

    private static object lockObj = new object();

    
    public void SquareOne(int thread)
    {
            lock (lockObj)
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                double res = 0;

                for (double x = 0; x < 1;)
                {
                    x += 0.00001;
                    res += 0.00001 * Math.Sin(x);

                    for (int i = 0; i < 100000; i++)
                    {
                        double a = i * i;
                    }

                    progress?.Invoke(x, thread);
                }

                stopwatch.Stop();

                long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;


                result?.Invoke(res);

                time?.Invoke(elapsedMilliseconds);
            }
    }

    private Semaphore semaphore = new Semaphore(1, 1);
    
    public void setSemaphore(int max)
    {
        semaphore = new Semaphore(max, max, "SuperSem");
    }


    public void SquareMany(int thread)
    {

        semaphore.WaitOne();  
        
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                double res = 0;

                for (double x = 0; x < 1;)
                {
                    x += 0.00001;
                    res += 0.00001 * Math.Sin(x);

                    for (int i = 0; i < 100000; i++)
                    {
                        double a = i * i;
                    }

                    progress?.Invoke(x, thread);
                }

                stopwatch.Stop();

                long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;


                result?.Invoke(res);

                time?.Invoke(elapsedMilliseconds);
        
        semaphore.Release();   
    }
}
