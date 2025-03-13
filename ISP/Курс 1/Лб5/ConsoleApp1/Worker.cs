

using System.Diagnostics;

class Worker
{

    public Worker() { }
    public Worker(string name, string second_name, Education education_type) {
        Name = name;
        Second_name = second_name;
        this.education_type = education_type;
    }

    private List<Work> lstWork = new List<Work>();
    private string name;
    private string second_name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Second_name
    {
        get { return second_name; }
        set { second_name = value; }
    }

    public List<Work> LstWork
    {
        get { return lstWork; }
    }

    public enum Education
    {
        University,
        Colleg
    }

    public Education education_type;


    public void AddWorkToCurrentWorker(string name_work, int payment)
    {
        Work new_men = new Work(name_work, payment);
        lstWork.Add(new_men);
    }

    public void Print_work()
    {
        foreach (Work work in lstWork)
        {
            Console.WriteLine("{0} {1}", work.Name_work, work.Payment);
        }

        if (lstWork.Count == 0)
        {
            Console.WriteLine("Список пустой");
        }
    }

    public int Sum_payment()
    {
        int ans = 0;
        for (int i = 0; i < lstWork.Count(); i++)
        {
            ans += lstWork[i].Payment;
        }
        return ans;
    }

}