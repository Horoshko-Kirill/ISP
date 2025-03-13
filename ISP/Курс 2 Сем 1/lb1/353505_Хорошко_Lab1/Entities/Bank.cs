

using System.Numerics;

namespace GenericMath
{


	public class Bank : IBank
	{

		private MyCustomCollection<Person> Persons = new MyCustomCollection<Person>();

		public Bank() { }
		public void AddPerson(string Name, string SecondName, string LastName)
		{
			Person person = new Person(Name, SecondName, LastName);
			Persons.Add(person);
		}

		public void AddDeposit(int NumberOfPerson, double Money, double Procent)
		{
			if (NumberOfPerson < Persons.Count)
			{
				Persons[NumberOfPerson].AddDeposit(Money, Procent);
			}
			else
			{
				Console.WriteLine("User exeption: Index out of range");
				Environment.Exit(1);
			}
		}


		public void TopUpDeposit(int NumberOfPerson, int NumberOfDeposit, double SumOfDeposit)
		{
			Persons[NumberOfPerson][NumberOfDeposit].TopUpMoney(SumOfDeposit);
		}

		private T Add<T>(T lhs, T rhs) where T : INumber<T>
		{
			return lhs + rhs;
		}


		private T Multiply<T>(T lhs, T rhs) where T : INumber<T>
		{
			return lhs*rhs;
		}

		public double ProcentOfDeposit(int NumberOfPerson, int NumberOfDeposit)
		{
			return Multiply(Multiply(Persons[NumberOfPerson][NumberOfDeposit].Money, Persons[NumberOfPerson][NumberOfDeposit].Procent), 0.01);
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