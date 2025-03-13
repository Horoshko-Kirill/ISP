

class Program()
{
    static void Main(string[] args)
    {
        var characters = new List<Str>();

        var student = new StudentBuilder();

        var legal = new LegalBuilder();

        characters.AddRange(new Str[]
        {
            Director.GetIPCottege("KSK", student),
            Director.GetPFCottege("ОМА", legal),
            Director.GetOrgApartment("ГомельСтрой", student),
            Director.GetIPHouse("BSUIR", student),
            Director.GetPFHouse("BSU", student),
            Director.GetIPApartment("Пряники", legal)
        }) ; 
            
    }
}