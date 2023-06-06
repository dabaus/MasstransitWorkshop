using Billing.Domain.Commands;
using Billing.MessageContracts.Commands;

namespace Billing.Processing.Mappers;

public interface IMessageMapper
{
    public ICreateOrderCommand Msg2Command(CreateOrderCommandMsg msg);
}