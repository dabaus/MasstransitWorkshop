using Billing.Processing.Consumers;
using MassTransit;
using Microsoft.Extensions.Hosting;

public class Program
{

    public static async Task Main(string[] args)
    {
        var builder = CreateHostBuilder(args);
        var host = builder.Build();
        await host.RunAsync();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddMassTransit(x =>
                {
                    x.AddConsumer<CreateOrderConsumer>();
                    
                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host("localhost", "/", h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });
                        cfg.ConfigureEndpoints(context);
                    });
                });
            });
    }
}