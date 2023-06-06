using Billing.Domain.Queries;
using Billing.Domain.QueryHandlers;
using Billing.Application.Queries;
using Billing.Domain.Repositories;

namespace Billing.Application.QueryHandlers;

public class FindOrderByIdQueryHandler : IFindOrderByIdQueryHandler
{
    private IOrderReadRepository _repository;
    
    public FindOrderByIdQueryHandler(IOrderReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<IFindOrderByIdQueryResult> Handle(IFindOrderByIdQuery query)
    {
        var order = await _repository.FindOrder(query.OrderId);
        return new FindOrderByIdQueryResult()
        {
            Order = order
        };
    }
}