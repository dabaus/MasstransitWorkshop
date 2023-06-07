using Billing.Domain.Exceptions;

namespace Billing.Application.ValueObjects;

public class OrderId
{
    public Guid Value { get; }
    
    public OrderId(string id)
    {
        if (!Guid.TryParse(id, out var result))
        {
            throw new InvalidValueException($"Invalid order id {id}");
        };
        Value = result;
    }

    public OrderId(Guid id)
    {
        Value = id;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}