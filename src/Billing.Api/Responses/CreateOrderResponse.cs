using Billing.Api.Dto;

namespace Billing.Api.Responses;

public class CreateOrderResponse
{
    public required Guid OrderId { get; set; }
    public CreateOrderStatusDto Status { get; set; }
}