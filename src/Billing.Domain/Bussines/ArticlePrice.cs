namespace Domain.Bussines;

public class ArticlePrice
{
    public required decimal VatRate { get; set; }
    public required decimal VatAmount  { get; set; }
    public required decimal NonVatAmount  { get; set; }

    public ArticlePrice()
    {
    }
    public decimal AmountToPay()
    {
        return VatAmount + NonVatAmount;
    }
};