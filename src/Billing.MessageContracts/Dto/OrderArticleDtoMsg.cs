namespace Billing.MessageContracts.Dto;

public class OrderArticleDtoMsg
{
    public required string SKU { get; set; }
    public required string Name { get; set; }
    public required int Quantity { get; set; }
    public required string Unit { get; set; }
    public required ArticlePriceDtoMsg TotalPrice { get; set; }
}