using Microsoft.Extensions.Configuration;

namespace Billing.Infrastructure.Config;

public class MartenConfiguration
{
    public string ConnectionString { get; private set; }
    
    public MartenConfiguration(IConfiguration config)
    {
        ConnectionString = config.GetConnectionString("Marten") ??
                           throw new Exception("Marten connection string not configured");
    }
}