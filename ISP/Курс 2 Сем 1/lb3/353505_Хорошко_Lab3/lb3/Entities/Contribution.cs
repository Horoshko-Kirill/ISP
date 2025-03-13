

public class Contribution
{
    public double Money;
    public double Procent;


    public Contribution(double Money, double Procent)
    {
        this.Money = Money;
        this.Procent = Procent;
    }

    public void TopUpMoney(double Money)
    {
        this.Money += Money;
    }

}