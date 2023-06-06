using Billing.Domain.Bussines;

namespace Billing.Domain.Repositories;

public interface IOrderWriteRepository
{
    public Task Store(Order order);
    
}