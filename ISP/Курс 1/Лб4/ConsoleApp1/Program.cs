
class Program
{
    static void Main(string[] args)
    {
        char t = '1';
        while (t != '0')
        {
            Department company = Department.GetInstance();
            Console.WriteLine("Введите имя компании");
            company.name = Console.ReadLine();
            Console.WriteLine("Введите число работников");
            company.amount_worker = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите норму выработки часов");
            company.norm_work.set_norm_vork_oklock(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Введите оплату за час");
            company.payment_oklock = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите подоходный налог в %");
            company.tax = Convert.ToInt32(Console.ReadLine());

            Console.Write("Общая выплата по подоходному налогу : ");
            Console.WriteLine(company.Sum_tax());

            Console.WriteLine("Введите не 0, если хотите продолжить");
            t = Convert.ToChar(Console.ReadLine());
        }
    }
}