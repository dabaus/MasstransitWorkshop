using Billing.Application.ValueObjects;
using Domain.Bussines;

namespace Billing.Domain.Bussines;

public class Order
{
    public required OrderId OrderId { get; set; }
    public required CustomerId CustomerId { get; set; }
    public required string OrderNumber { get; set;  }
    public required CurrencyCode CurrencyCode { get; set;  }
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


