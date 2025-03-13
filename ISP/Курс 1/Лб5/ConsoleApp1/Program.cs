

class Program
{

    static int Input()
    {
        int number = 0;
        while (true)
        {
            try
            {
                Console.WriteLine("Введите число:");
                string input = Console.ReadLine();
                number = Convert.ToInt32(input); // Попытка преобразования введенной строки в число
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка формата ввода! Введите корректное число.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка переполнения! Введите число в допустимом диапазоне.");
            }
        }
        return number;
    }
    static void Main(string[] args)
    {
        Departament MyDepartment = new Departament();

        string t = "1";
        int index = 0;

        while (t != "0")
        {
            if (MyDepartment.Log)
            {
                MyDepartment.Print_current_name();
                Console.WriteLine("Выберите одну из функций:");
                Console.WriteLine("1) Добавить работу рабочему");
                Console.WriteLine("2) Вывести работы рабочего");
                Console.WriteLine("3) Вывести выплаты");
                Console.WriteLine("4) Выйти из страницы");
                index = Program.Input();
                switch (index)
                {
                    case 1:
                        Console.WriteLine("Введите название работы");
                        string name_work;
                        name_work = Console.ReadLine();
                        bool buf = MyDepartment.AddWorkCurrent(name_work);
                        if (!buf)
                        {
                            Console.WriteLine("Данная работа не найдена в списке работ");
                        }
                        break;
                    case 2:
                        MyDepartment.Print_work_current_worker();
                        break;
                    case 3:
                        MyDepartment.Print_salary_current_work();
                        break;
                    case 4:
                        MyDepartment.LogOut();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Выберите одну из функций:");
                Console.WriteLine("1) Добавить рабочего");
                Console.WriteLine("2) Добавить работу");
                Console.WriteLine("3) Удалить рабочего");
                Console.WriteLine("4) Удалить работу");
                Console.WriteLine("5) Вывести всех рабочих");
                Console.WriteLine("6) Вывести все работы");
                Console.WriteLine("7) Выбрать рабочего по фамилии");
                Console.WriteLine("8) Выбрать рабочего по имени");
                Console.WriteLine("9) Вывести информацию о выплатах");
                index = Program.Input();
                switch (index) {
                    case (1):
                        string secong_name;
                        Console.WriteLine("Введите фамилию ");
                        secong_name = Console.ReadLine();
                        string name;
                        Console.WriteLine("Введите имя ");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите 0, если высшее образование, 1, если образование среднее специальное ");
                        int a = -1;
                        a= Program.Input();
                        while (a < 0 || a > 1)
                        {
                            Console.WriteLine("Повторите попытку ");
                            a = Program.Input();
                        }
                        if (a == 0)
                            MyDepartment.AddWorker(name, secong_name, Worker.Education.University);
                        else
                            MyDepartment.AddWorker(name, secong_name, Worker.Education.Colleg);
                        break;
                    case (2):
                        Console.WriteLine("Введите название работы");
                        string name_work;
                        name_work = Console.ReadLine();
                        Console.WriteLine("Введите оплату");
                        int price = 0;
                        price = Program.Input();
                        while (price < 0)
                        {
                            Console.WriteLine("Повторите попытку");
                            price = Program.Input();
                        }
                        MyDepartment.AddWork(name_work, price);
                        break;
                    case (3):
                        Console.WriteLine("Введите фамилию ");
                        string Second_name = Console.ReadLine();
                        MyDepartment.DeleteWorker(Second_name);
                        break;
                    case (4):
                        Console.WriteLine("Введите название работы");
                        string work;
                        work = Console.ReadLine();
                        MyDepartment.DeleteWork(work);
                        break;
                    case (5):
                        MyDepartment.Print_all_workers();
                        break;
                    case (6):
                        MyDepartment.Print_all_works();
                        break;
                    case (7):
                        Console.WriteLine("Введите фамилию");
                        string second_name = Console.ReadLine();
                        MyDepartment.LogIn_second_name(second_name);
                        break;
                    case (8):
                        Console.WriteLine("Введите имя");
                        string log_name = Console.ReadLine();
                        MyDepartment.LogIn_worker_name(log_name);
                        break;
                    case (9):
                        MyDepartment.Get_all_salary();
                        break;
                    default:
                        Console.WriteLine("Функция не найдена ");
                        break;
                }
                Console.WriteLine("Если хотите продолжить введите не 0");
                t = Console.ReadLine();
            }
        }
        
    }
}