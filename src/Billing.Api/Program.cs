using System.Text.Json.Serialization;
using Billing.Api.Mappers;
using Billing.Api.Modules;
using Billing.Application.CommandHandlers;
using Billing.Application.QueryHandlers;
using Billing.Domain.CommandHandlers;
using Billing.Domain.QueryHandlers;
using Billing.Domain.Repositories;
using Billing.Infrastructure.Extensions;
using Billing.Infrastructure.Mappers;
using Billing.Infrastructure.Repository;

namespace Billing.Api;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddSingleton<OrderModule>();
        builder.Services.AddHealthChecks();

        //Command handlers
        builder.Services.AddSingleton<ICreateOrderCommandHandler, CreateOrderCommandHandler>();
        
        //Query handlers
        builder.Services.AddSingleton<IFindOrderByIdQueryHandler, FindOrderByIdQueryHandler>();
        
        //Repositories
        builder.Services.AddSingleton<OrderRepository>();
        builder.Services.AddSingleton<IOrderWriteRepository>(x => x.GetRequiredService<OrderRepository>());
        builder.Services.AddSingleton<IOrderReadRepository>(x => x.GetRequiredService<OrderRepository>());
        
        //Mappers
        builder.Services.AddSingleton<IDaoMapper, DaoMapper>();
        builder.Services.AddSingleton<IDtoMapper, DtoMapper>();
        
        //Infra 
        builder.Services.ConfigureMarten();
        
        builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
        {
            var converter = new JsonStringEnumConverter();
            options.SerializerOptions.Converters.Add(converter);
        });
        
        
        var app = builder.Build();

        app.UseHealthChecks("/healthchecks");
        Module.RegisterAllEndpoints(app);
        
        app.Run();
    }
}

