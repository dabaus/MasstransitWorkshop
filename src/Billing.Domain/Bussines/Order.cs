using Domain.Bussines;

namespace Billing.Domain.Bussines;

public class Order
{
    public required Guid OrderId { get; set; }
    
    public required Guid CustomerId { get; set; }
    public required string OrderNumber { get; set;  }
    public required string CurrencyCode { get; set;  }
    public required List<OrderArticle> OrderArticles { get; set;  }
    
    
    public Decimal TotalAmountToPay()
    {
        return OrderArticles.Select(x => x.TotalPrice.AmountToPay()).Sum();
    }

    public Decimal TotalExclVat()
    {
        return OrderArticles.Select(x => x.TotalPrice.NonVatAmount).Sum();
    }

    public Decimal TotalVat()
    {
        return OrderArticles.Select(x => x.TotalPrice.VatAmount).Sum();
    }

    public Decimal WeightedAvgVatRate()
    {
        var result =
            (from article in OrderArticles
            group article.TotalPrice.VatAmount by article.TotalPrice.VatRate
            into g
            select new { VatRate = g.Key, TotalVat = g.Sum() })
            .ToList();

        var totalVatAmount = result.Sum(x => x.TotalVat);

        return result.Select(x => new
        {
            WeightedVat = (x.VatRate / 100m) * (x.TotalVat / totalVatAmount )
        }).Sum(x => x.WeightedVat);
    }

    public static OrderBuilder Create(Guid orderId)
    {
        return new OrderBuilder(orderId);
    }
}

public class OrderBuilder
{
    private Guid _orderId;
    private string _currencyCode;
    private List<OrderArticle> _orderArticles;
    private Guid _customerId;
    
    public OrderBuilder(Guid orderId)
    {
        _orderId = orderId;
    }

    public OrderBuilder WithCurrency(string currency)
    {
        _currencyCode = currency;
        return this;
    }

    public OrderBuilder WithArticles(List<OrderArticle> articles)
    {
        _orderArticles = articles;
        return this;
    }
    
    public OrderBuilder WithCustomer(Guid customerId)
    {
        _customerId = customerId;
        return this;
    }

    public Order Build()
    {
        if (string.IsNullOrEmpty(_currencyCode))
        {
            throw new Exception("Currency code cannot be empty");
        }
        if (_customerId == default)
        {
            throw new Exception("Customer id must be set");
        }

        return new Order()
        {
            OrderId = _orderId,
            CurrencyCode = _currencyCode,
            OrderArticles = _orderArticles,
            OrderNumber = GenerateOrderNumber(),
            CustomerId = _customerId
        };
    }

    public static string GenerateOrderNumber()
    {
        Random rnd = new Random();
        var d1 = rnd.Next() % 16;
        var d2 = rnd.Next() % 16;
        var d3 = rnd.Next() % 16;
        
        var date = DateTime.UtcNow.ToString("yyMMddHHmmss");

        return $"{date}{d1:X}{d2:X}{d3:X}";
    }
}