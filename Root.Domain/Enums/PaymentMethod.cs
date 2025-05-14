namespace Root.Domain.Enums;

public enum PaymentMethod
{
    Express,
    Transference, 
    Reference,
    PayPay
}

public static class PaymentMethodExtension
{
    public static string ToFriendlyString(this PaymentMethod method)
    {
        return method switch
        {
            PaymentMethod.Express => "Multicaixa Express",
            PaymentMethod.Reference => "Pagamento por Referencia",
            PaymentMethod.PayPay => "PayPay",
            PaymentMethod.Transference => "Transferencia Bancaria",
            _ => ""
        };
    }
}