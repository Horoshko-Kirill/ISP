
using GenericMath;

class Program
{
    static void Main()
    {


        Bank AlfaBank = new Bank();


        AlfaBank.AddPerson("Хорошко", "Кирилл", "Николаевич");

        AlfaBank.AddPerson("Иванов", "Александр", "Владимирович");

        AlfaBank.AddDeposit(0, 100, 10);
        AlfaBank.AddDeposit(0, 150, 20);

        AlfaBank.AddDeposit(1, 20, 10);
        AlfaBank.AddDeposit(1, 10, 10);
        AlfaBank.AddDeposit(1, 25, 10);

        Console.WriteLine(AlfaBank.PrintPerson(0));
        Console.WriteLine(AlfaBank.PrintPerson(1));

        AlfaBank.TopUpDeposit(0, 0, 200);
        AlfaBank.TopUpDeposit(1, 0, 200);

        Console.WriteLine(AlfaBank.PrintPerson(0));
        Console.WriteLine(AlfaBank.PrintPerson(1));


        Console.Write("Процент вклада первого депозита Кирилла:");
        Console.WriteLine(AlfaBank.ProcentOfDeposit(0, 1));

        Console.Write("\nОбщая сумма вклада с процентом Кирилла:");
        Console.WriteLine(AlfaBank.Amount(0));


        Console.Write("\nОбщая сумма вклада с процентом Александра:");
        Console.WriteLine(AlfaBank.Amount(1));

    }
}