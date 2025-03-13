

using System.Runtime.InteropServices;

static public class Task1
{
    public static double func(uint n, double x)
    {

        double ans = 1;

        for (int i = 0; i < n; i++)
        {
            ans = ans * x;
        }

        return ans /= n;
    }
}