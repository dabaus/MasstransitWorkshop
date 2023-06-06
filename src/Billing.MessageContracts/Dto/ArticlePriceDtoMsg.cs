namespace Billing.MessageContracts.Dto;

public class ArticlePriceDtoMsg
{
    public required decimal VatRate { get; set; }
    public required decimal VatAmount  { get; set; }
    public required decimal NonVatAmount  { get; set; }
}