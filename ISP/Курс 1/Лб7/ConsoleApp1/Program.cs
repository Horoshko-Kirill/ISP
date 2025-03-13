

using System.Collections.Specialized;

public class quadric
{
    public double a;
    public double b;
    public double c;

    public quadric(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        solve();
    }

    private double x1;
    private double x2;
    bool solved = false;

    private void solve()
    {
        double D = b * b - 4 * a * c;
        if (D < 0)
        {
            solved = false;
            return;
        }
        if (D == 0)
        {
            solved = true;
            x1 = -b / (2 * a);
            x2 = x1;
            return;
        }
        if (D > 0)
        {
            solved = true;
            D = Math.Sqrt(D);
            x1 = (-b - D) / 2 / a;
            x2 = (-b + D) / 2 / a;
            return;
        }
    }

    public double X1
    {
        get
        {
            if (solved)
            {
                return x1;
            }
            else
            {
                return -9999999999999;
            }
        }
    }

    public double X2
    {
        get
        {
            if (solved)
            {
                return x2;
            }
            else
            {
                return -9999999999999;
            }
        }
    }

    public static quadric operator + (quadric a, quadric b)
    {
        return new quadric(a.a + b.a, a.b + b.b, a.c + b.c);
    }

    public static quadric operator -(quadric a, quadric b)
    {
        return new quadric(a.a - b.a, a.b - b.b, a.c - b.c);
    }

    public static bool operator ==(quadric a, quadric b)
    {
        if (a.a == b.a && a.b == b.b && a.c == b.c)
        {
            return true;
        }
        else return false;
    }

    public static bool operator !=(quadric a, quadric b)
    {
        if (a.a == b.a && a.b == b.b && a.c == b.c)
        {
            return false;
        }
        else return true;
    }
    public static quadric operator +(quadric a, int val)
    {
        return new quadric(a.a, a.b, a.c + val);
    }

    public static quadric operator -(quadric a, int val)
    {
        return new quadric(a.a, a.b, a.c - val);
    }

    public static quadric operator *(quadric a, int val)
    {
        return new quadric(a.a * val, a.b * val, a.c * val) ;
    }

    public static quadric operator /(quadric a, int val)
    {
        return new quadric(a.a / val, a.b / val, a.c / val);
    }

    public static quadric operator ++(quadric a)
    {
        return new quadric(a.a, a.b, a.c + 1);
    }

    public static quadric operator --(quadric a)
    {
        return new quadric(a.a, a.b, a.c - 1);
    }

    public string print()
    {
        return "a = " + a + " b = " + b + " c = " + c;
    }
}



class Program
{

    static double Input()
    {
        double number = 0;
        while (true)
        {
            try
            {
                Console.WriteLine("Введите число:");
                string input = Console.ReadLine();
                number = Convert.ToDouble(input); // Попытка преобразования введенной строки в число
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
        double a;
        double b;
        double c;
        Console.WriteLine("Введите коэффициенты a, b, c первого уравнения");
        Console.Write("a = ");
        a = Input();
        Console.Write("b = ");
        b = Input();
        Console.Write("c = ");
        c = Input();
        quadric quadr1 = new quadric(a, b, c);
        Console.WriteLine("Введите коэффициенты a, b, c второго уравнения");
        Console.Write("a = ");
        a = Input();
        Console.Write("b = ");
        b = Input();
        Console.Write("c = ");
        c = Input();
        quadric quadr2 = new quadric(a, b, c);
        if (quadr1.X1 != -9999999999999)
        {
            Console.WriteLine("Корни первого уравнения x1 = {0} x2 = {1}", quadr1.X1, quadr1.X2);
        }
        else
        {
            Console.WriteLine("Первое уравнения не имеет корней");
        }

        if (quadr2.X1 != -9999999999999)
        {
            Console.WriteLine("Корни второго уравнения x1 = {0} x2 = {1}", quadr2.X1, quadr2.X2);
        }
        else
        {
            Console.WriteLine("Второе уравнения не имеет корней");
        }

        quadric ans;

        ans = quadr1 + quadr2;

        Console.WriteLine("Коэфициенты суммы уравнений : " + ans.print());

        ans = quadr1 - quadr2;

        Console.WriteLine("Коэфициенты разности уравнений : " + ans.print());

        if (quadr1 == quadr2)
        {
            Console.WriteLine("Уравнения одинаковы");
        }

        if (quadr1 != quadr2)
        {
            Console.WriteLine("Уравнения различны");
        }

        ans = quadr1 + 5;

        Console.WriteLine("Коэфициенты уравнения 1 в сумме с 5 : " + ans.print());

        ans = quadr1 - 5;

        Console.WriteLine("Коэфициенты уравнения 1 в разнице с 5 : " + ans.print());

        ans = quadr1 * 5;

        Console.WriteLine("Коэфициенты уравнения 1 при произведении с 5 : " + ans.print());

        ans = quadr1 / 5;

        Console.WriteLine("Коэфициенты уравнения 1 при делении на 5 : " + ans.print());

        quadr1++;

        Console.WriteLine("Коэфициенты уравнения 1 с операцией ++ : " + quadr1.print());

        quadr2--;

        Console.WriteLine("Коэфициенты уравнения 2 с операцией -- : " + quadr2.print());
    }
}