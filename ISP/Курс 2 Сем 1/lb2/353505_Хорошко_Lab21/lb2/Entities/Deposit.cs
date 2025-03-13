


using System.Runtime.CompilerServices;

internal class Deposit
{

    private string Name;
    private double procent;

    public Deposit(string name, double procent)
    {
        Name = name;
        this.procent = procent;
    }

    public string NameOfDeposit => Name;
    public double ProcentOfDeposit => procent;

}

