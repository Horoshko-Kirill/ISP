
    class Airport
    {

    public Airport() { }

    private List<Tarif> tarifs = new List<Tarif>();
   public void AddDiscoun(int discount, int price, string way)
    {
        Discount buf = new Discount(discount, price, way);
        Tarif tarif = new Tarif(buf);
        tarifs.Add(tarif);
    }
   public void AddNoDiscoun(int price, string way)
    {
        NoDiscount buf = new NoDiscount(price, way);
        Tarif tarif = new Tarif(buf);
        tarifs.Add(tarif);
    }

    public string Way()
    {
        int ind = 0;
        int max = -100000;
        for (int i = 0; i < tarifs.Count; i++)
        {
            if (tarifs[i].GetPrice() > max)
            {
                ind = i;
                max = tarifs[i].GetPrice();
            }
        }


        return tarifs[ind].GetWay(); 
    }
}

