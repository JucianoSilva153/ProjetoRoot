namespace Root.Domain.Enums;

public enum UserType
{
    Administrator,
    Client,
    Guide
}

public static class UserTypeExtension
{
    public static string ToFriendlyString(this UserType type)
    {
        return type switch
        {
            UserType.Administrator => "Administrador",
            UserType.Client => "Cliente",
            UserType.Guide => "Guia"
        };
    }
}