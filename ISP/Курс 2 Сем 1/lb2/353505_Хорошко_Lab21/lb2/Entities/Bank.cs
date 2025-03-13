

using System.Numerics;
using System.Xml.Linq;

namespace GenericMath
{
    public class Bank : IBank
    {

        private MyCustomCollection<Person> Persons = new MyCustomCollection<Person>();
        private MyCustomCollection<Deposit> Deposits = new MyCustomCollection<Deposit>();

        public event Action<string, string> PersonAndDepositChanged;
        public event Action<string> ChangeContribution;

        public string NameEntity;
        public Bank(string NameOfEntity) {
            this.NameEntity = NameOfEntity;
        }
        public void AddPerson(string Name, string SecondName, string LastName)
        {
            Person person = new Person(Name, SecondName, LastName);
            Persons.Add(person);

            PersonAndDepositChanged?.Invoke("Person", NameEntity);

        }

        public void AddDeposit(string Name, double Procent)
        {
            Deposits.Add(new Deposit(Name, Procent));

            PersonAndDepositChanged?.Invoke("Deposit", NameEntity);
        }

        public void PrintAvailableDeposit()
        {
            for (int i = 0; i < Deposits.Count; i++)
            {
                Console.WriteLine(Deposits[i] + "- " + Deposits[i]);
            }
        }
        public void AddContibution(string NameOfPerson, double Money, string NameOfDeposit)
        {
            int NumberOfDeposit = Deposits.Count;

            for (int i = 0; i < NumberOfDeposit; i++)
            {
                if (Deposits[i].NameOfDeposit == NameOfDeposit)
                {
                    NumberOfDeposit = i;
                }
            }

            int NumberOfPerson = Persons.Count;

            for (int i = 0; i < NumberOfPerson; i++)
            {
                if (Persons[i].Name == NameOfPerson)
                {
                    NumberOfPerson = i;
                }
            }

            if (NumberOfPerson < Persons.Count & NumberOfDeposit < Deposits.Count)
            {
                Persons[NumberOfPerson].AddContibution(Money, Deposits[NumberOfDeposit].ProcentOfDeposit);
            }
            else
            {
                Console.WriteLine("User exeption: Index out of range");
                Environment.Exit(1);
            }

            ChangeContribution?.Invoke(Persons[NumberOfPerson].Name);
        }



        public void TopUpDeposit(int NumberOfPerson, int NumberOfContribution, double SumOfDeposit)
        {
            Persons[NumberOfPerson][NumberOfContribution].TopUpMoney(SumOfDeposit);

        }

        private T Add<T>(T lhs, T rhs) where T : INumber<T>
        {
            return lhs + rhs;
        }


        private T Multiply<T>(T lhs, T rhs) where T : INumber<T>
        {
            return lhs * rhs;
        }

        public double ProcentOfDeposit(int NumberOfPerson, int NumberOfContribution)
        {
            return Multiply(Multiply(Persons[NumberOfPerson][NumberOfContribution].Money, Persons[NumberOfPerson][NumberOfContribution].Procent), 0.01);
        }


        public double Amount(int NumberOfPerson)
        {
            double amount = 0;

            for (int i = 0; i < Persons[NumberOfPerson].Count(); i++)
            {
                amount = Add(Add(ProcentOfDeposit(NumberOfPerson, i), Persons[NumberOfPerson][i].Money), amount);
            }


            return amount;
        }


        public string PrintPerson(int NumberOfPerson)
        {
            string print = "";

            print += Persons[NumberOfPerson].Name + " ";
            print += Persons[NumberOfPerson].FirstName + " ";
            print += Persons[NumberOfPerson].LastName + " ";

            print += "\n";

            for (int i = 0; i < Persons[NumberOfPerson].Count(); i++)
            {
                print += i + ") ";
                print += "Сумма вклада " + Persons[NumberOfPerson][i].Money + " Процент " + Persons[NumberOfPerson][i].Procent + "\n";
            }


            return print;
        }
    }
}