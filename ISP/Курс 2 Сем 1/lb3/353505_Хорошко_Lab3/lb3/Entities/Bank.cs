

using System.Numerics;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Reflection;

namespace GenericMath
{
    public class Bank : IBank
    {

        private List<Person> Persons = new List<Person>();
        private Dictionary<string, Deposit> Deposits = new Dictionary<string, Deposit>();

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
            Deposits.Add(Name,new Deposit(Name, Procent));

            PersonAndDepositChanged?.Invoke("Deposit", NameEntity);
        }

        public void PrintAvailableDeposit()
        {
            foreach (var deposit in Deposits)
            {
                Console.WriteLine(deposit.Key + " - " + deposit.Value.ProcentOfDeposit + '%');
            } 
            Console.WriteLine();
        }

        public void PrintSortDeposit()
        {
            var orderDeposit = from deposit in Deposits orderby deposit.Value.ProcentOfDeposit select deposit.Value;

            foreach (var deposit in orderDeposit)
            {
                Console.WriteLine(deposit.NameOfDeposit + " - " + deposit.ProcentOfDeposit + "%");
            }

            Console.WriteLine();
        }

        public void AddContibution(string NameOfPerson, double Money, string NameOfDeposit)
        {
        
            int NumberOfPerson = Persons.Count();

            for (int i = 0; i < NumberOfPerson; i++)
            {
                if (Persons[i].Name == NameOfPerson)
                {
                    NumberOfPerson = i;
                }
            }

            if (NumberOfPerson < Persons.Count() & Deposits.ContainsKey(NameOfDeposit))
            {
                Persons[NumberOfPerson].AddContibution(Money, Deposits[NameOfDeposit].ProcentOfDeposit);
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


        public double AmountPerson(int NumberOfPerson)
        {
            double amount = 0;

            for (int i = 0; i < Persons[NumberOfPerson].Count(); i++)
            {
                amount = Add(ProcentOfDeposit(NumberOfPerson, i), amount);
            }


            return amount;
        }

        public double AmountPersonContribution(int NumberOfPerson)
        {
            double amount = 0;

            for (int i = 0; i < Persons[NumberOfPerson].Count(); i++)
            {
                amount = Add(Persons[NumberOfPerson][i].Money, amount);
            }


            return amount;
        }


        public double AmountProcent()
        {
            double amount = 0;

            for (int i = 0; i < Persons.Count(); i++)
            {
                amount += AmountPerson(i);
            }

            return amount;
        }


        public string MaxProcent()
        {

            Dictionary<string, double> result = new Dictionary<string, double>();

            for (int i = 0;i < Persons.Count(); i++)
            {
                result.Add(Persons[i].Name, AmountPerson(i));
            }


            var maxPerson = result.Aggregate((x, y) => x.Value > y.Value ? x : y);
            string maxKey = maxPerson.Key;

            return maxKey;

        }

        public int countOfPersonGrade(double money)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();

            for (int i = 0; i < Persons.Count(); i++)
            {
                result.Add(Persons[i].Name, AmountPersonContribution(i));
            }

            int count = 0;

            count = result.Aggregate(0, (count, x) => x.Value > money ? count + 1 : count);

            return count;
        }

        public double AmountContribution()
        {
            double amount = 0;

            var listContribution = from person in Persons select person.AmoutnContribution();

            foreach (var personContribution in listContribution)
            {
                amount += personContribution;
            }

            return amount;
        }


        public string ListPersons()
        {
            var allDeposits = Persons.SelectMany(p => p.ContributionList.Select(d => new
            {
                ClientName = p.Name,
                Amount = d.Money
            }))
           .GroupBy(p => p.ClientName)
           .Select(g => new { Name = g.Key, TotalAmount = g.Sum(d => d.Amount)}); 

            string res = "";

            foreach(var person in allDeposits)
            {
                res += $"{person.Name} - {person.TotalAmount}\n";
            }

            return res;
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