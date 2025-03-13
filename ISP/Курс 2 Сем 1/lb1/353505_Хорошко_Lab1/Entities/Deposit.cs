

public class Deposit
{
    public double Money;
    public double Procent;
   

    public Deposit(double Money, double Procent)
    {
        this.Money = Money;
        this.Procent = Procent;
    }

    public void TopUpMoney(double Money)
    {
        this.Money += Money;
    }

}