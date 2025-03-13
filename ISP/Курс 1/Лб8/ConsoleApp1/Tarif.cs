
    internal class Tarif 

    {

    private IBilet air;
    public    Tarif (IBilet air)
    {
        this.air = air;
    }

    public int GetPrice()
    {
        return air.GetPrice();
    }

    public string GetWay()
    {
        return air.GetWay();
    }

    }

