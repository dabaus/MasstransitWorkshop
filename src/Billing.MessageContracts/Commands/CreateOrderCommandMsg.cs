using Billing.MessageContracts.Dto;

namespace Billing.MessageContracts.Commands;

public interface CreateOrderCommandMsg
{
    public Guid OrderId { get; set; }
    public string OrderNumber { get; set;  }
    public string CurrencyCode { get; set;  }
    public Guid CustomerId { get; set; }
    public List<OrderArticleDtoMsg> OrderArticles { get; set;  }
}