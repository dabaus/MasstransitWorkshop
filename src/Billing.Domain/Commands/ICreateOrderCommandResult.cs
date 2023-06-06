namespace Billing.Domain.Commands;

public interface ICreateOrderCommandResult
{
    public Guid OrderId { get; set; }
    public bool AlreadyExists { get; set; } 
}