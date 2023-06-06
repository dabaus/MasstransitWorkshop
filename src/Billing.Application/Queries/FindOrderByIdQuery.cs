using Billing.Domain.Bussines;
using Billing.Domain.Queries;

namespace Billing.Application.Queries;

public class FindOrderByIdQuery : IFindOrderByIdQuery
{
    public required Guid OrderId { get; set; }
}

public class FindOrderByIdQueryResult : IFindOrderByIdQueryResult
{
    public required Order Order { get; set; }
}