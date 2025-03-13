


using LoremNET;

class Programm
{
    static async Task Main()
    {

        IProgress<string> progress = new Progress<string>(message =>
        {
            Console.WriteLine(message);
        });

        progress.Report($"Главный поток {Thread.CurrentThread.ManagedThreadId} начал работу");

        List<Courses> list = new List<Courses>();
        Random random = new Random();

        for (int i = 0; i < 1000; i++)
        {
            Courses item = new Courses(random.Next(), Lorem.Words(1), random.Next()%30);
            list.Add(item);
        }

        StreamService<Courses> streamService = new StreamService<Courses>();

        streamService.serviceEvents += Print;

        string fileName = "Courses.json";

        MemoryStream stream = new MemoryStream();

        var t2 = streamService.CopyFromStreamAsync(stream, fileName, progress);
        var t1 = streamService.WriteToStreamAsync(stream, list, progress);
        

        await t1;
        await t2;

        Console.WriteLine($"Количество курсов со слушателями больше 19: {streamService.GetStaticAsync(fileName, Statistics).Result}");

        progress.Report($"Главный поток {Thread.CurrentThread.ManagedThreadId} завершил pаботу");
    }

    static void Print(string message)
    {
        Console.WriteLine(message);
    }

    static bool Statistics(Courses item)
    {
        return (item.Listeners > 19);
    }
}