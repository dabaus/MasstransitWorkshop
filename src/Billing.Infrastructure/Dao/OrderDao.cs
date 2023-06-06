using Marten.Schema;

namespace Persistence.Dao;

public class OrderDao
{
    [Identity]
    public required Guid Id { get; set; }
    
    public required string OrderNumber { get; set; }
    public required string CurrencyCode { get; set; }
    public required List<OrderArticleDao> Articles{ get; set; }
    
    public required Guid CustomerId { get; set; }
}
    