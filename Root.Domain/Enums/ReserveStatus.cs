namespace Root.Domain.Enums;

public enum ReserveStatus
{
    Pending,
    Confirmed,
    Cancelled,
    Reviewed
}

public static class ReserveStatusExtension
{
    public static string ToFriendlyString(this ReserveStatus status)
    {
        return status switch
        {
            ReserveStatus.Cancelled => "Cancelado",
            ReserveStatus.Confirmed => "Confirmado",
            ReserveStatus.Pending => "Pendente",
            ReserveStatus.Reviewed => "Revisado"
        };
    }
}