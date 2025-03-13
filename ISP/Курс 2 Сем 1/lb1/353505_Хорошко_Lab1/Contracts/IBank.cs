

interface IBank
{

    void AddPerson(string Name, string SecondName, string LastName);

    void AddDeposit(int NumberOfPerson, double Money, double Procent);
    void TopUpDeposit(int NumberOfPerson, int NumberOfDeposit, double SumOfDeposit);

    double Amount(int NumberOfPerson);

    double ProcentOfDeposit(int NumberOfPerson, int NumberOfDeposit);

}