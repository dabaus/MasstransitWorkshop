using Billing.Domain.Commands;

namespace Billing.Domain.CommandHandlers;

public interface ICreateOrderCommandHandler
{
    public Task<ICreateOrderCommandResult> Handle(ICreateOrderCommand command);
}
