using Billing.Domain.Queries;

namespace Billing.Domain.QueryHandlers;

public interface IFindOrderByIdQueryHandler
{
    public Task<IFindOrderByIdQueryResult> Handle(IFindOrderByIdQuery query);
}