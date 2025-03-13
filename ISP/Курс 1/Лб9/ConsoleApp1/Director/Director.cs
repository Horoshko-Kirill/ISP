
    static class Director
    {
        public static Str GetOrgCottege(string name, Builder builder)
    {
        return builder.SetName(name)
            .SetType(Type.type.Organization)
            .SetWork(new Cottege())
            .Build();
    }

    public static Str GetOrgHouse(string name, Builder builder)
    {
        return builder.SetName(name)
            .SetType(Type.type.Organization)
            .SetWork(new House())
            .Build();
    }

    public static Str GetOrgApartment(string name, Builder builder)
    {
        return builder.SetName(name)
            .SetType(Type.type.Organization)
            .SetWork(new Apartment())
            .Build();
    }

    public static Str GetIPCottege(string name, Builder builder)
    {
        return builder.SetName(name)
            .SetType(Type.type.IP)
            .SetWork(new Cottege())
            .Build();
    }

    public static Str GetIPHouse(string name, Builder builder)
    {
        return builder.SetName(name)
            .SetType(Type.type.IP)
            .SetWork(new House())
            .Build();
    }

    public static Str GetIPApartment(string name, Builder builder)
    {
        return builder.SetName(name)
            .SetType(Type.type.IP)
            .SetWork(new Apartment())
            .Build();
    }

    public static Str GetPFCottege(string name, Builder builder)
    {
        return builder.SetName(name)
            .SetType(Type.type.Person_Company)
            .SetWork(new Cottege())
            .Build();
    }

    public static Str GetPFHouse(string name, Builder builder)
    {
        return builder.SetName(name)
            .SetType(Type.type.Person_Company)
            .SetWork(new House())
            .Build();
    }

    public static Str GetPFApartment(string name, Builder builder)
    {
        return builder.SetName(name)
            .SetType(Type.type.Person_Company)
            .SetWork(new Apartment())
            .Build();
    }

}
