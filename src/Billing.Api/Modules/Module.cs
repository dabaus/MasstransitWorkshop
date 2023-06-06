namespace Billing.Api.Modules;

public abstract class Module
{

    protected abstract void RegisterEndpoints(WebApplication app);

    public static void RegisterAllEndpoints(WebApplication app)
    {
        var type = typeof(Module);
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p) && p != type);

        foreach (var t in types)
        {
            var module= (Module)app.Services.GetService(t)!;
            module.RegisterEndpoints(app);
        }
    }
    
}