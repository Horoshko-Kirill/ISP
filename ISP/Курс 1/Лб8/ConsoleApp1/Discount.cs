

    internal class Discount : IBilet
    {

        private int discount;
        private int Price;
        private string way;
    
        public Discount(int discount, int price, string way)
    {
        this.way = way;
        this.discount = discount;
        this.Price = price;
    }

        public int GetPrice()
        {
        return Price - discount;
        }

    public string GetWay()
    {
        return way;
    }
    }