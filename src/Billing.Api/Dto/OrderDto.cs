namespace Billing.Api.Dto;

public class OrderDto
{
    public required Guid OrderId { get; set; }
    public required string CurrencyCode { get; set; }
    public required string OrderNumber { get; set; }
    public required Guid CustomerId { get; set; }
    public required List<OrderArticleDto> OrderArticles { get; set; }
}