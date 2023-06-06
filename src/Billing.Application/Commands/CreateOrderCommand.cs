using Billing.Domain.Commands;
using Domain.Bussines;

namespace Billing.Application.Commands;

public class CreateOrderCommand : ICreateOrderCommand
{
    public required Guid OrderId { get; set; }
    public required string CurrencyCode { get; set; }
    public required Guid CustomerId { get; set; }
    public required List<OrderArticle> OrderArticles { get; set; }
}

public class CreateOrderCommandResult : ICreateOrderCommandResult
{
    public required Guid OrderId { get; set; }
    public bool AlreadyExists { get; set; } 
}
