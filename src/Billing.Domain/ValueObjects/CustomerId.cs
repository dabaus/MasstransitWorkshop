using Billing.Domain.Exceptions;

namespace Billing.Application.ValueObjects;

public class CustomerId
{
    public Guid Value { get; }
    
    public CustomerId(string id)
    {
        if (!Guid.TryParse(id, out var result))
        {
            throw new InvalidValueException($"Invalid customer id {id}");
        };
        Value = result;
    }

    public CustomerId(Guid id)
    {
        Value = id;
    }
}