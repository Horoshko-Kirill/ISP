

public class Person
{

    public string Name;
    public string FirstName;
    public string LastName;

    public List<Contribution> ContributionList = new List<Contribution>();

    public Person(string name, string firstName, string lastName)
    {
        Name = name;
        FirstName = firstName;
        LastName = lastName;
    }

    public Contribution this[int index]
    {
        get
        {
            return ContributionList[index];
        }
    }

    public void AddContibution(double Money, double Procent)
    {
        Contribution deposit = new Contribution(Money, Procent);
        ContributionList.Add(deposit);
    }

    public int Count()
    {
        return ContributionList.Count;
    }

    public double AmoutnContribution()
    {
        double amount = 0;

        foreach(Contribution contribution in ContributionList)
        {
            amount += contribution.Money;
        }

        return amount;
    }

}