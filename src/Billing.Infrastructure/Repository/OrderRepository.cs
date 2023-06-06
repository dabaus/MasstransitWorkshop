using Billing.Domain.Bussines;
using Billing.Domain.Repositories;
using Billing.Infrastructure.Mappers;
using Marten;
using Microsoft.AspNetCore.Http;
using Persistence.Dao;

namespace Billing.Infrastructure.Repository;

public class OrderRepository : IOrderWriteRepository, IOrderReadRepository
{
    private readonly IDocumentStore _db;
    private readonly IDaoMapper _daoMapper;
    
    public OrderRepository(IDocumentStore db, IDaoMapper daoMapper)
    {
        _db = db;
        _daoMapper = daoMapper;
    }
    
    public async Task Store(Order order)
    {
        var dao = _daoMapper.DomainOrder2Dao(order);
        await using var session = _db.LightweightSession();
        session.Store(dao);
        await session.SaveChangesAsync();
    }

    public async Task<Order?> FindOrder(Guid id)
    {
        await using var session = _db.QuerySession();
        var dao = await session.LoadAsync<OrderDao>(id);
        
        return dao == null ? null : _daoMapper.OrderDao2Domain(dao);
    }

    public async Task<List<Order>> FindAllOrdersForCustomer(Guid customerId)
    {
        await using var session = _db.QuerySession();
        var results = await session.Query<OrderDao>()
            .Where(x => x.CustomerId == customerId)
            .ToListAsync();

        return results.Select(_daoMapper.OrderDao2Domain).ToList();
    }

  
    
}