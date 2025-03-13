
using System;
static public class Task2
{
    static public int func(double z, out double y)
    {
        double x;
        int i;

        if (z >= 1)
        {
            x = z - 1;
            i = 1;
        }
        else
        {
            x = z * z + 1;
            i = 2;
        }

        y = (Math.Pow(Math.E, Math.Pow(Math.Sin(x), 3)) + Math.Log(x + 1)) / Math.Sqrt(x);
        return i;
    }
}