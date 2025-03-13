using System.Reflection;


class Program
{

    static void Main()
    {

        Assembly asm = Assembly.LoadFrom("../../../Debug/net8.0/FileServise.dll");
        foreach (var t in asm.GetTypes())
        {
            Console.WriteLine(t.FullName);
        }

        Type type = asm.GetType("FileService`1");

        Type concreteType = type.MakeGenericType(typeof(Employee));

        var read = concreteType.GetMethod("ReadFile");
        var save = concreteType.GetMethod("SaveData");

        

        object fileServiceInstance = Activator.CreateInstance(concreteType);


        string filename = ConfigHelper.GetFileName();

        string fileName = filename + ".txt";

        var employes = new List<Employee>
        {
            new Employee
            {
                Age = 18,
                NewEmployee = true,
                Name = "Kirill"
            },
            new Employee
            {
                Age = 23,
                NewEmployee = true,
                Name = "Egor"
            },
            new Employee
            {
                 Age = 18,
                 NewEmployee = true,
                 Name = "Artem"
            },
            new Employee
             {
                 Age = 40,
                 NewEmployee = false,
                 Name = "Vlad"
            },
            new Employee
            {
                 Age = 68,
                 NewEmployee = false,
                 Name = "Dasha"
            }
        };

        save.Invoke(fileServiceInstance, new object[] { employes, fileName });


        IEnumerable<Employee> emplo = (IEnumerable<Employee>)read.Invoke(fileServiceInstance, new object[] { fileName });

        foreach(var t in emplo)
        {
            Console.WriteLine($" Name : {t.Name} \n newEmploye : {t.NewEmployee} \n Age : {t.Age} \n");
        }
    }

}