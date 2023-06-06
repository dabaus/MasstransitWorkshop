using System.Net;
using Billing.Api.Dto;
using Billing.Api.Mappers;
using Billing.Api.Requests;
using Billing.Api.Responses;
using Billing.Application.Commands;
using Billing.Application.Queries;
using Billing.Domain.Bussines;
using Billing.Domain.CommandHandlers;
using Billing.Domain.QueryHandlers;
using Billing.Infrastructure.Mappers;
using Domain.Bussines;
using Microsoft.AspNetCore.Mvc;

namespace Billing.Api.Modules;

public class OrderModule : Module
{

    public OrderModule() : base()
    {
        Console.WriteLine("Instance");
    }
    protected override void RegisterEndpoints(WebApplication app)
    {
        app.MapGet("/orders/{id}", Get);
        app.MapPost("/orders", Post);

    }
    private async Task<CreateOrderResponse> Post(CreateOrderRequest request, 
        ICreateOrderCommandHandler handler,
        IDtoMapper mapper)
    {
        var cmd = new CreateOrderCommand()
        {
            CurrencyCode = request.CurrencyCode,
            CustomerId = request.CustomerId,
            OrderArticles = request.OrderArticles.Select(mapper.OrderArticleDtoToDomain).ToList(),
            OrderId = request.OrderId
        };
        
        var result = await handler.Handle(cmd);

        return new CreateOrderResponse()
        {
            OrderId = result.OrderId,
            Status = result.AlreadyExists ? CreateOrderStatusDto.Exists : CreateOrderStatusDto.Created
        };
    }
    private async Task<FindOrderResponse> Get(Guid id, 
        IFindOrderByIdQueryHandler handler, 
        IDtoMapper mapper)
    {
        var result = await handler.Handle(new FindOrderByIdQuery()
        {
            OrderId = id
        });
        return new FindOrderResponse()
        {
            Order = mapper.OrderToDto(result.Order)
        };
    }
    
    
}       