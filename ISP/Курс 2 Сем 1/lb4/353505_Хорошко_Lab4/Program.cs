

internal class Program
{
    static void CreateOrClearFolder(string folderPath)
    {
        if (Directory.Exists(folderPath))
        {
            foreach (var file in Directory.GetFiles(folderPath))
            {
                File.Delete(file);
            }

            foreach (var dir in Directory.GetDirectories(folderPath))
            {
                Directory.Delete(dir, true);
            }
        }
        else
        {
            Directory.CreateDirectory(folderPath);
        }
    }
    static void Main()
    {

        string folderName = "Хорошко_Lab4"; 
        string folderPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        CreateOrClearFolder(folderPath);
        Console.WriteLine($"Папка '{folderPath}' подготовлена.");

        string[] extensions = { ".txt", ".rtf", ".dat", ".inf" };

        Random random = new Random();

        for (int i = 0; i < 10; i++)
        {
            string fileName = Path.GetRandomFileName(); 
            string extension = extensions[random.Next(extensions.Length)];

   
            fileName = Path.ChangeExtension(fileName, extension);

            string filePath = Path.Combine(folderPath, fileName);

            File.Create(filePath).Dispose();
        }


        string[] files = Directory.GetFiles(folderPath);


        foreach (var file in files)
        {

            string fileName = Path.GetFileName(file);


            string fileExtension = Path.GetExtension(file);


            Console.WriteLine($"Файл {fileName} имеет расширение {fileExtension}");
        }


        List<Listener> myCourses = new List<Listener>();

        myCourses.Add(new Listener("Kirill", 18, true));
        myCourses.Add(new Listener("Srtem", 15, false));
        myCourses.Add(new Listener("Sasha", 12, true));
        myCourses.Add(new Listener("Pasha", 32, false));
        myCourses.Add(new Listener("Katya", 48, false));

        FileServis fileMeneger = new FileServis();

        List<object[]> data = new List<object[]>();

        foreach (Listener listener in myCourses)
        {
            object[] buf = new object[3];

            buf[0] = listener.Name;
            buf[1] = listener.Age;
            buf[2] = listener.Vip;

            data.Add(buf);
        }

        folderPath = "C:\\Users\\kiril\\Desktop\\Lb_c#\\Курс 2\\lb4\\353505_Хорошко_Lab4\\bin\\Debug\\net8.0";

        string oldFileName = "myCourses.bin";

        fileMeneger.SaveData(data, oldFileName);

        string newFileName = "mySchool";

        string oldFilePath = Path.Combine(folderPath, oldFileName);
        string newFilePath = Path.Combine(folderPath, newFileName);

        if (File.Exists(newFileName))
        {
            File.Delete(newFileName);
        }

        File.Move(oldFilePath, newFilePath);

        IEnumerable<object[]> fullData = fileMeneger.ReadFile(newFileName);

        var listeners = fullData
           .Select(data => new Listener((string)data[0], (int)data[1], (bool)data[2]))
           .ToList();

        var customComparer = new MyCustomComparer();

        var sortedListeners = listeners.OrderBy(listener => listener, customComparer).ToList();


        Console.WriteLine("Сортировка по имени:");
        foreach (var listener in sortedListeners)
        {
            Console.WriteLine($"Имя: {listener.Name}, Возраст: {listener.Age}, VIP: {listener.Vip}");
        }

        var sortedByAge = from listener in listeners
                          orderby listener.Age
                          select listener;

        Console.WriteLine("Сортировка по возрасту:");
        foreach (var listener in sortedByAge)
        {
            Console.WriteLine($"Имя: {listener.Name}, Возраст: {listener.Age}, VIP: {listener.Vip}");
        }

        var sortedByVip = from listener in listeners
                          orderby listener.Vip descending  
                          select listener;

        Console.WriteLine("Сортировка по статусу VIP (сначала VIP):");
        foreach (var listener in sortedByVip)
        {
            Console.WriteLine($"Имя: {listener.Name}, Возраст: {listener.Age}, VIP: {listener.Vip}");
        }

    }

}