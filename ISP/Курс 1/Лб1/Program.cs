
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Print first number : ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Print second number : ");
        double b = Convert.ToDouble(Console.ReadLine());
        double result = a / b;
        Console.WriteLine("Quotient of a/b = {0}", result);
    }
}