namespace Billing.Api.Dto;

public class ArticlePriceDto
{
    public required decimal VatRate { get; set; }
    public required decimal VatAmount  { get; set; }
    public required decimal NonVatAmount  { get; set; }
}