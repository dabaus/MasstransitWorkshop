using Billing.Domain.Bussines;

namespace Billing.Domain.Queries;

public interface IFindOrdersResult
{
    public List<Order> Result { get; set; }
}