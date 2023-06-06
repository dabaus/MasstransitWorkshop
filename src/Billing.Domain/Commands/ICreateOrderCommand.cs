using Domain.Bussines;

namespace Billing.Domain.Commands;

public interface ICreateOrderCommand
{
    public Guid OrderId { get; set; }
    public string CurrencyCode { get; set;  }
    public Guid CustomerId { get; set;  }
    public List<OrderArticle> OrderArticles { get; set;  }
}

