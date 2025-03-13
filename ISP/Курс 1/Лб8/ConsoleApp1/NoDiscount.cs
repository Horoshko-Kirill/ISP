

internal class NoDiscount : IBilet
{

    private int Price;
    private string way;
    
    public NoDiscount(int price, string way)
    {
        this.way = way;
        this.Price = price;
    }

    public int GetPrice()
    {
        return Price;
    }

    public string GetWay()
    {
        return way;
    }

}