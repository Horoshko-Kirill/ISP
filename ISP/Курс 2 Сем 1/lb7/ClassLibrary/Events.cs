using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class Events
{
    public void PrintResult(double res)
    {
        Console.WriteLine($"\nРезультат : {res}");
    }

    public void PrintTime(long time)
    {
        Console.WriteLine($"Время : {time}");
    }


    public void PrintProgress(double x, int threadId) 
    {
        int totalLength = 20;

        int filledLength = (int)(x * totalLength);

        string progressBar = new string('=', filledLength);

        if (filledLength < 20)
        {
            progressBar += ">";
            progressBar.PadRight(totalLength - 1 - filledLength, ' ');
        }

        int percentage = (int)(x * 100);
        Console.Write($"\rПоток {threadId}: [{progressBar}] {percentage}%");
    }
}


