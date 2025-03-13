

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public abstract class Geometry
{
    protected abstract int S();
    protected abstract int P();

    protected int angel_value(int amount_side)
    {
        return 180 * (amount_side - 2);
    }

    public virtual string print_figure() {
        return "";
    }

}

public class Rectangle : Geometry
{
    public int a = 0;
    public int b = 0;
    protected int angle;

    public Rectangle()
    {

        angle = base.angel_value(4)/4;
    }
    public Rectangle(int a, int b)
    {
        this.a = a;
        this.b = b;
        angle = base.angel_value(4)/4;
    }
    

    protected override int S()
    {
        return a * b;
    }

    protected override int P()
    {
        return 2 * (a + b);
    }

    public sealed override string print_figure()
    {
        return "a = " + a + " b = " + b + " S = " + S() + " P = " + P() + " Угол: " + angle;
    }
}

public sealed class Circle : Geometry
{
    public int R;

    public Circle(){    }
    public Circle(int R)
    {
        this.R = R;
    }

    protected sealed override int S()
    {
        return 3 * R;
    }

    protected sealed override int P()
    {
        return 6 * R;
    }

    public sealed override string print_figure()
    {
        return "R = " + R + " S = " + S() + " P = " + P();
    }
}

public sealed class Square : Rectangle
{
    public Square(int a) : base()
    {
        this.a = a;
        angle = base.angle;
    }

    new int S()
    {
        return a * a;
    }

    new int P()
    {
        return 4*a;
    }

   
    public string square()
    {
        return "a = " + a + " S = " + S() + " P = " + P() + " Угол: " + angle + " Rectangle P: " + base.P();
    }
}

class Program
{

    static void Main(string[] args)
    {

        Rectangle rect = new Rectangle(5, 10);
        Square square = new Square(20);
        Circle circle = new Circle(40);

        Console.WriteLine(rect.print_figure());
        
        Console.WriteLine(square.square());

        Console.WriteLine(circle.print_figure());
    }


}