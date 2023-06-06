using Billing.Domain.Queries;

namespace Billing.Domain.QueryHandlers;

public interface IFindOrderByCustomerIdQueryHandler
{
    public Task<IFindOrdersResult> Handle(IFindOrderByCustomerIdQuery idQuery);
}