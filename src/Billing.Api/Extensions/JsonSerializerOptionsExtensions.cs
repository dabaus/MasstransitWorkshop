using System.Text.Json;
using System.Text.Json.Serialization;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;


namespace Billing.Api.Extensions;

public static class JsonSerializerOptionsExtensions
{
    public static JsonOptions SetCustomOptions(this JsonOptions options)
    {
        options.SerializerOptions.SetCustomOptions();
        return options;
    }
    
    public static JsonSerializerOptions SetCustomOptions(this JsonSerializerOptions options)
    {
        var converter = new JsonStringEnumConverter();
        options.Converters.Add(converter);
        options.PropertyNameCaseInsensitive = true;
        return options;
    }
    
}