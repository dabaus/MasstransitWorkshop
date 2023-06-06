using Billing.Api.Dto;
using Domain.Bussines;

namespace Billing.Api.Requests;

public class CreateOrderRequest
{
    public required Guid OrderId { get; set; }
    public required string CurrencyCode { get; set; }
    public required Guid CustomerId { get; set; }
    public required List<OrderArticleDto> OrderArticles { get; set; }
}