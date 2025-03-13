

class Programm
{
    static void Main(string[] args)
    {
        Airport buf = new Airport();

        int n = 0;

        Console.WriteLine("Введите число тарифов");
        n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int k;

            Console.WriteLine("Введите 1, если со скидкой, 0 если без");

            k = Convert.ToInt32(Console.ReadLine());

            if (k == 1)
            {
                int buf1;
                int buf2;
                string buf3;
                Console.WriteLine("Введите скидку");
                buf1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите цену");
                buf2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите направление");
                buf3 = Console.ReadLine();
                buf.AddDiscoun(buf1, buf2, buf3);
            }
            else
            {
                int buf1;
                string buf3;
                Console.WriteLine("Введите цену");
                buf1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите направление");
                buf3 = Console.ReadLine();
                buf.AddNoDiscoun(buf1, buf3);
            }
        }
        Console.WriteLine("Путь с наибольшей стоимотью");
        Console.WriteLine(buf.Way());
    }
}