using Billing.Domain.Bussines;

namespace Billing.Domain.Repositories
{
    public interface IOrderReadRepository
    {
        public Task<Order?> FindOrder(Guid id);

        public Task<List<Order>> FindAllOrdersForCustomer(Guid customerId);
    }
}