using Billing.Infrastructure.Config;
using Marten;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Dao;
using Weasel.Core;

namespace Billing.Infrastructure.Extensions;

public static class MartenConfigurationExtensions
{
    public static IServiceCollection ConfigureMarten(this IServiceCollection  provider)
    {
        provider.AddSingleton<MartenConfiguration>();
        
        provider.AddMarten(x =>
        {
            var config = x.GetRequiredService<MartenConfiguration>();
            StoreOptions options = new ();
            options.Connection(config.ConnectionString);
            options.Schema.For<OrderDao>().DocumentAlias("order");;
            options.AutoCreateSchemaObjects = AutoCreate.All;
            return options;
        });
        return provider;
    } 
}