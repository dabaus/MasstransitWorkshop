using Billing.Api.Dto;

namespace Billing.Api.Responses;

public class FindOrdersResponse
{
    public required List<OrderDto> Orders { get; set; }
}