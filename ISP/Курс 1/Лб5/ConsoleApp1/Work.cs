

class Work {

    private string name_work;
    private int payment;

    public Work(string name_work, int payment)
    {
        this.name_work = name_work;
        this.payment = payment;
    }

    public Work() { }

    public string Name_work {
        get { return name_work; }
        set { name_work = Name_work; }
    }
    
    public int Payment
    {
        get { return payment; }
        set { payment = Payment; }
    }
}