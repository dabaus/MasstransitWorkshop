using Billing.Domain.Exceptions;

namespace Billing.Application.ValueObjects;

public class CurrencyCode
{
    public string Value { get; }
    
    public CurrencyCode(string currencyCode)
    {
        var code = currencyCode.ToUpper();
        switch (code)
        {
            case "SEK":
                break;
            case "EUR":
                break;
            case "USD":
                break;
            default:
                throw new InvalidValueException($"Invalid currency code {code}");
        }
        Value = code;
    }
    
    public override string ToString()
    {
        return Value;
    }
}