using Billing.Api.Dto;

namespace Billing.Api.Responses;

public class FindOrderResponse
{
    public required OrderDto Order { get; set;  } 
}