using Billing.Domain.CommandHandlers;
using Billing.MessageContracts.Commands;
using Billing.MessageContracts.Events;
using Billing.Processing.Mappers;
using MassTransit;

namespace Billing.Processing.Consumers;

public class CreateOrderConsumer : IConsumer<CreateOrderCommandMsg>
{

    private IBus _bus;
    private ICreateOrderCommandHandler _commandHandler;
    private IMessageMapper _mapper;

    public CreateOrderConsumer(IBus bus, ICreateOrderCommandHandler commandHandler, IMessageMapper mapper)
    {
        _bus = bus;
        _commandHandler = commandHandler;
        _mapper = mapper;
    }
    
    public async Task Consume(ConsumeContext<CreateOrderCommandMsg> context)
    {
        var result = await _commandHandler.Handle(_mapper.Msg2Command(context.Message));
        await _bus.Publish<OrderCreatedEventMsg>(new OrderCreateEventMsgMsg()
        {
            OrderId = result.OrderId
        });
    }
    
    public class OrderCreateEventMsgMsg : OrderCreatedEventMsg 
    {
        public Guid OrderId { get; set; }
    }
}