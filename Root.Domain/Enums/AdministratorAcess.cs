namespace Root.Domain.Enums;

public enum AdministratorAcess
{
    All
}

public static class AdministratorAcessExtension
{
    public static string ToFriendlyString(this AdministratorAcess acess)
    {
        return acess switch
        {
            AdministratorAcess.All => "Todos"
        };
    }

    public static List<string> ToStringList(this List<AdministratorAcess> acesses)
    {
        List<string> list = [];

        acesses.ForEach(e => { list.Add(e.ToFriendlyString()); });

        return list;
    }
}