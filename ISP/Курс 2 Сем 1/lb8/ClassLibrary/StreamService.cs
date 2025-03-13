using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


public class StreamService<T>
{

    public event Action<string> serviceEvents;

    private SemaphoreSlim semaphore = new SemaphoreSlim(0, 1);
    public async Task WriteToStreamAsync(Stream stream, IEnumerable<T> data, IProgress<string> progress)
    {

        serviceEvents.Invoke($"Поток {Thread.CurrentThread.ManagedThreadId} начал работу. WriteToStreamAsync");

        StreamWriter str = new StreamWriter(stream, leaveOpen : true);
        
            foreach(T item in data)
            {
                string serializedData = JsonConvert.SerializeObject(item);
                str.WriteLine(serializedData);
            }
        str.Flush();
        str.Close();

        Thread.Sleep(3000);

        serviceEvents.Invoke($"Поток {Thread.CurrentThread.ManagedThreadId} завершил работу. WriteToStreamAsync");
        semaphore.Release();
    }

    public async Task CopyFromStreamAsync(Stream stream, string fileName, IProgress<string> progress)
    {
        await semaphore.WaitAsync();
        serviceEvents.Invoke($"Поток {Thread.CurrentThread.ManagedThreadId} начал работу. CopyFromStreamAsync");

        stream.Seek(0, SeekOrigin.Begin);

        if (stream.Length > 0)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
        else
        {
            serviceEvents.Invoke("Поток пустой, нет данных для копирования.");
        }


        serviceEvents.Invoke($"Поток {Thread.CurrentThread.ManagedThreadId} завершил работу. CopyFromStreamAsync");
        semaphore = new SemaphoreSlim(0, 1);
    }

    public async Task<int> GetStaticAsync(string fileName, Func<T, bool> filter)
    {
        var result = new List<T>();
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                T item = JsonConvert.DeserializeObject<T>(line);
                result.Add(item);
            }
        }

        int res = 0;

        foreach (T item in result)
        {
            if (filter(item))
            {
                res++;
            }
        }

        return res;
    }
}

