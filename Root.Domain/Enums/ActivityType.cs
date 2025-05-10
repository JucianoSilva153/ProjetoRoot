namespace Root.Domain.Enums;

public enum ActivityType
{
    Nature,
    Adventure,
    Cultural,
    Recreational,
    None
}

public static class ActivityTypeExtensions
{
    public static string ToFriendlyString(this ActivityType activityType)
    {
        return activityType switch
        {
            ActivityType.Nature => "Natureza",
            ActivityType.Adventure => "Aventura",
            ActivityType.Cultural => "Cultural",
            ActivityType.Recreational => "Recreativo",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}