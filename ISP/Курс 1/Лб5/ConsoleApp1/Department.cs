


using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using static Worker;

class Departament
{

    public Departament() { }

    private List<Worker> workers = new List<Worker>();
    private List<Work> works = new List<Work>();


    private int current_worker;
    private bool log = false;
    public bool Log
    {
        get { return log; }
    }
    public void AddWorker(string name, string second_name, Education education_type)
    {
        Worker new_worker = new Worker(name, second_name, education_type);
        workers.Add(new_worker);
    }

    public void AddWork(string name_work, int payment)
    {
        Work new_work = new Work(name_work, payment);
        works.Add(new_work);
    }

    public void DeleteWorker(string second_name)
    {
        for (int i = 0; i < workers.Count(); i++)
        {
            if (workers[i].Second_name == second_name)
            {
                workers.RemoveAt(i);
                break;
            }
        }
    }

    public void DeleteWork(string name_work)
    {
        for (int i = 0; i < works.Count(); i++)
        {
            if (works[i].Name_work == name_work)
            {
                works.RemoveAt(i);
                break;
            }
        }
    }

    public void Print_all_workers()
    {
        if (workers.Count == 0)
        {
            Console.WriteLine("Список пустой");
        }
        else
        {
            foreach (var item in workers)
            {
                Console.WriteLine("{0} {1} {2}", item.Second_name, item.Name, item.education_type);
            }
        }
    }

    public void Print_all_works()
    {
        if (works.Count == 0)
        {
            Console.WriteLine("Список пустой");
        }
        else
        {
            foreach (var item in works)
            {
                Console.WriteLine("{0} {1}", item.Name_work, item.Payment);
            }
        }
    }

    public void LogIn_second_name(string second_name)
    {
        log = true;

        for (int i = 0; i < workers.Count(); i++)
        {
            if (workers[i].Second_name == second_name)
            {
                current_worker = i;
                log = true;
                break;
            }
            else
            {
                log = false;
            }
        }
        if (!log)
        {
            Console.WriteLine("Рабочий не найден");
        }
    }

    public void LogIn_worker_name(string name)
    {
        log = true;

        for (int i = 0; i < workers.Count(); i++)
        {
            if (workers[i].Name == name)
            {
                current_worker = i;
                log = true;
                break;
            }
            else
            {
                log = false;
            }
        }

        if (!log)
        {
            Console.WriteLine("Рабочий не найден");
        }
    }

    public void Print_current_name()
    {
        Console.WriteLine("Вы находитесь на странице рабочего {0} {1}", workers[current_worker].Second_name, workers[current_worker].Name);
    }
    public bool AddWorkCurrent(string work_name)
    {
            for (int i = 0; i < works.Count(); i++)
            {
            if (works[i].Name_work == work_name)
            {
                workers[current_worker].AddWorkToCurrentWorker(work_name, works[i].Payment);
                return true;
            }
            }
        return false;
    }
    
    public void Print_work_current_worker()
    {
        if (log)
        {
            workers[current_worker].Print_work();
        }
        
    }

    public void Print_salary_current_work()
    {
        if (log)
        {
           Console.WriteLine(workers[current_worker].Sum_payment());
        }
    }

    public void Get_all_salary()
    {
        int ans = 0;
        foreach (var worker in workers)
        {
            Console.WriteLine("{0} {1} {2}", worker.Second_name, worker.Name, worker.Sum_payment());
            ans += worker.Sum_payment();
        }
        if (works.Count == 0)
        {
            Console.WriteLine("Список пустой");
        }
        Console.WriteLine("Суммарная выплата по всем работникам {0}", ans);
    }

    public void LogOut()
    {
        log = false;
    }
}