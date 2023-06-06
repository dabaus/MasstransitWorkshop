using Billing.Api.Requests;
using Persistence.Dao;

namespace Billing.Api.Tests;

public class OrderUtils
{
    public static CreateOrderRequest CreateOrderWithId(Guid id)
    {
        return new CreateOrderRequest()
        {
            CurrencyCode = "SEK",
            CustomerId = Guid.NewGuid(),
            OrderId = id,
            OrderArticles = new ()
            {
                new ()
                {
                    Name = "Red baloon",
                    Quantity = 1,
                    Unit = "pcs",
                    SKU = "RB2",
                    TotalPrice = new ()
                    {
                        VatAmount = 2.5m,
                        NonVatAmount = 10,
                        VatRate = 25
                    }
                }
            }
        };
    }
}