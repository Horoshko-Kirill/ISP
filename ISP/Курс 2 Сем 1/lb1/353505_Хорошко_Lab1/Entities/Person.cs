

public class Person
{

    public string Name;
    public string FirstName; 
    public string LastName;

    private MyCustomCollection<Deposit> DepositList = new MyCustomCollection<Deposit>();

    public Person(string name, string firstName, string lastName)
    {
        Name = name;
        FirstName = firstName;
        LastName = lastName;
    }

    public Deposit this[int index]
    {
        get
        {
            return DepositList[index];
        }
    }

    public void AddDeposit(double Money, double Procent)
    {
        Deposit deposit = new Deposit(Money, Procent);
        DepositList.Add(deposit);
    }

    public int Count()
    {
        return DepositList.Count;
    }

}