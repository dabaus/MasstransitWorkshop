using Billing.Application.Commands;
using Billing.Application.Validation;
using Billing.Application.ValueObjects;
using Billing.Domain.Bussines;
using Billing.Domain.CommandHandlers;
using Billing.Domain.Commands;
using Billing.Domain.Repositories;
using Domain.Bussines;

namespace Billing.Application.CommandHandlers;

public class CreateOrderCommandHandler : ICreateOrderCommandHandler
{
    private readonly IOrderWriteRepository _writeRepo;
    private readonly IOrderReadRepository _readRepo;
    
    public CreateOrderCommandHandler(IOrderWriteRepository writeRepo, IOrderReadRepository readRepo)
    {
        _writeRepo = writeRepo;
        _readRepo = readRepo;
    }
    
    public async Task<ICreateOrderCommandResult> Handle(ICreateOrderCommand command)
    {
        // Check if order already exists
        if (await _readRepo.FindOrder(command.OrderId) != null)
        {
            return new CreateOrderCommandResult()
            {
                OrderId = command.OrderId,
                AlreadyExists = true
            };
        };
        
        var articles = new List<OrderArticle>();
        foreach (var article in command.OrderArticles)
        {
            ValidationUtils.ValidateOrderArticle(article);
            articles.Add(article);
        }
        
        var order = new Order()
        {
            OrderId = new OrderId(command.OrderId),
            CurrencyCode = new CurrencyCode(command.CurrencyCode),
            OrderArticles = articles,
            OrderNumber = Order.GenerateOrderNumber(),
            CustomerId = new CustomerId(command.CustomerId)
        };

        await _writeRepo.Store(order);

        return new CreateOrderCommandResult()
        {
            OrderId = order.OrderId.Value,
            AlreadyExists = false
        };
    }
    
}
