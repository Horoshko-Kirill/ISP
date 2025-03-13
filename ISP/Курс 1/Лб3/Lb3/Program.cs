
class Program
{

    static private int Integer()
    {
        int buf = 0;

        while (true)
        {
            try
            {
                Console.WriteLine("Введите значение: ");
                buf = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода");
            }
        }

        return buf;
    }
    static private double Double()
    {
        double buf = 0;

        while (true)
        {
            try
            {
                buf = Convert.ToDouble(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода");
            }
        }

        return buf;
    }
    static void Main(string[] args)
    {
        char t = '0';
        while (true)
        {
            Console.Write("Номер задания. ");
            int num_task = Program.Integer();

            switch (num_task)
            {
                case 1:
                    Console.Write("x. ");
                    double x = Program.Double();
                    double ans = Task1.func(2, x) + Task1.func(4, x) + Task1.func(6, x);
                    Console.WriteLine("Ответ: {0}", ans);
                    break;

                case 2:
                    double y;
                    Console.Write("z. ");
                    double z = Program.Double();
                    int i = Task2.func(z, out y);
                    if (i == 1)
                    {
                        Console.WriteLine("Программа выполнялось по ветке 1");
                    }
                    else
                    {
                        Console.WriteLine("Программа выполнялось по ветке 2");
                    }
                    Console.WriteLine("Ответ: {0}", y);
                    break;

                case 3:
                    Console.Write("Введите дату формата dd.MM.yyyy: ");
                    string date;
                    while (true)
                    {
                        date = Console.ReadLine();
                        if (DateTime.TryParseExact(date, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out _))
                        {
                            Console.WriteLine("День недели: {0}", Task3.DataServis.GetDay(date));
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Введенная строка не является допустимой датой.");
                        }
                    }
                    while (true) {
                        Console.Write("День. ");
                        int day = Program.Integer();
                        Console.Write("Месяц. ");
                        int month = Program.Integer();
                        Console.Write("Год. ");
                        int year = Program.Integer();
                        if (DateTime.TryParse($"{day}/{month}/{year}", out DateTime dat))
                        {
                            Console.WriteLine("Количество дней между текущей датой и данной {0}", Task3.DataServis.GetDaysSpan(day, month, year));
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Некоректная дата");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Нет задания с таким номером");
                    break;
            }
            Console.Write("Введите не 0, если хотите продолжить ");
            t = Convert.ToChar(Console.ReadLine());
            if (t == '0')
            {
                break;
            }
        }
    }
}