using Billing.Domain.Bussines;

namespace Billing.Domain.Queries;

public interface IFindOrderByIdQueryResult
{
    public Order Order { get; set; }
}