namespace Billing.MessageContracts.Events;

public interface OrderCreatedEventMsg
{
    public Guid OrderId { get; set; } 
}