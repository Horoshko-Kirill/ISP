

internal interface IBank
{

    void AddPerson(string Name, string SecondName, string LastName);

    void TopUpDeposit(int NumberOfPerson, int NumberOfDeposit, double SumOfDeposit);

    double AmountPerson(int NumberOfPerson);

    double ProcentOfDeposit(int NumberOfPerson, int NumberOfDeposit);

}