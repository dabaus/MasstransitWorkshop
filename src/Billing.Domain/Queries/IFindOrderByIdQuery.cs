namespace Billing.Domain.Queries;

public interface IFindOrderByIdQuery
{
    public Guid OrderId { get; set; }
}