




using GenericMath;

class Program
{


    static void Main()
    {

        Bank AlfaBank = new Bank("AlfaBank");
        Journal journal = new Journal();

        AlfaBank.PersonAndDepositChanged += journal.LogEvent;
        AlfaBank.ChangeContribution += LogEvent;

        AlfaBank.AddDeposit("Большой", 25);
        AlfaBank.AddDeposit("Средний", 15);
        AlfaBank.AddDeposit("Маленький", 5);

        AlfaBank.AddPerson("Хорошко", "Кирилл", "Николаевич");
        AlfaBank.AddPerson("Иванов", "Иван", "Иванович");

        AlfaBank.AddContibution("Хорошко", 100, "Большой");
        AlfaBank.AddContibution("Хорошко", 50, "Большой");
        AlfaBank.AddContibution("Хорошко", 25, "Большой");

        AlfaBank.AddContibution("Иванов", 200, "Большой");
        AlfaBank.AddContibution("Иванов", 1000, "Большой");

        Console.WriteLine(AlfaBank.PrintPerson(0));
        Console.WriteLine(AlfaBank.PrintPerson(1));

        AlfaBank.PrintAvailableDeposit();

        AlfaBank.PrintSortDeposit();

        Console.WriteLine(AlfaBank.AmountContribution());

        Console.WriteLine(AlfaBank.AmountProcent() + "\n");

        Console.WriteLine(AlfaBank.MaxProcent() + "\n");

        Console.WriteLine(AlfaBank.countOfPersonGrade(100) + "\n");

        Console.WriteLine(AlfaBank.ListPersons() + "\n");

        journal.ExEvent();

    }

    static void LogEvent(string NameOfPerson)
    {
        Console.WriteLine(NameOfPerson + " сделал(а) влкад");
    }


}