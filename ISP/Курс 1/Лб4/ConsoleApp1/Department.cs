
using System.Runtime.CompilerServices;

class Department
{

    private static Department department;
    private Department() { }
   
    public string name;
    public int amount_worker;
    public Norm_work norm_work = new Norm_work();
    public int payment_oklock;

    private int Tax;
    public int tax
    {
        get
        {
            return Tax;
        }

        set
        {
            if (value < 0 || value > 100)
            {
                Console.WriteLine("Вы ввели неверное значение. Значение по умолчанию 10%");
                Tax = 10;  
            }
            else
            {
                Tax = value;
            }
        }
    }


    static public Department GetInstance()
    {

        if (department == null)
        {
            department =  new Department();
        }

        return department;
    }

    public double Sum_tax()
    {
        return (double)Department.department.amount_worker * Department.department.payment_oklock * Department.department.Tax / 100;
    }

}