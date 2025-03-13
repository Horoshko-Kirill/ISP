
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
            {
        bool run = true;

        while (run)
        {
            short number_task = 0;
            bool task = true;
            Console.Write("Введите номер задания : ");
            while (task)
            {
                try
                {
                    number_task = Convert.ToInt16(Console.ReadLine());
                    if (number_task > 2 || number_task < 1)
                    {
                        Console.WriteLine("Вы зашли за границу, повторите ввод");
                    }
                    else
                    {
                        task = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка формата ввода, повторите ввод");
                }
            }

            switch (number_task) {

                case 1: 
                {
                        Console.WriteLine("Задание 1: ");
                        int num = 0;
                        bool flag = true;

                        Console.Write("Введите число : ");

                        while (flag)
                        {
                            try
                            {
                                num = Convert.ToInt32(Console.ReadLine());
                                if ((num < 100 && num > 9) || (num > -100 && num < -9))
                                {
                                    flag = false;
                                }
                                else
                                {
                                    Console.WriteLine("Число не является двухзначным");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ошибка формата ввода, повторите ввод");
                            }
                        }
                        num = Math.Abs(num);
                        int digit = num % 10;
                        num /= 10;
                        if (num == digit)
                        {
                            Console.WriteLine("Цифры одинаковы");
                        }
                        else
                        {
                            Console.WriteLine("Цифры различны");
                        }
                        break;
                }

                case 2:
                {
                        Console.WriteLine("Задание 2: ");

                        short x = 0;
                        short y = 0;
                        bool flag = true;

                        Console.WriteLine("Введите координаты x, y: ");

                        while (flag)
                        {
                            try
                            {
                                x = Convert.ToInt16(Console.ReadLine());
                                y = Convert.ToInt16(Console.ReadLine());
                                flag = false;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ошибка формата ввода, повторите ввод");
                            }
                        }

                        int f1 = x * x + y * y;
                        int f2 = -Math.Abs(x);

                        if (f1 < 625 && y < f2)
                        {
                            Console.WriteLine("Точка находится внутри");
                        }
                        else if ((f1 < 625 && y == f2) || (f1 == 625 && y < f2))
                        {
                            Console.WriteLine("Точка находится на границе");
                        }
                        else
                        {
                            Console.WriteLine("Точка находится за пределами области определения");
                        }
                        break;
                }
            }
            string t;
            Console.WriteLine("Если хотите закончить введите '0', иначе не '0'");
            t = Console.ReadLine();

            if (t.Length == 1 && t[0] == '0') run = false;
        }
    }
}