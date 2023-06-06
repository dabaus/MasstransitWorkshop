namespace Billing.Domain.Queries;

public interface IFindOrderByCustomerIdQuery
{
    public Guid CustomerId { get; set; }
}