using TZTDate.IdentityWebApi.Services;
using TZTDate.IdentityWebApi.Services.Base;

namespace TZTDate.IdentityWebApi.Extensions;

public static class DependencyInjectionExtensions
{
    public static void Inject(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAzureBlobService, AzureBlobService>();
        serviceCollection.AddSingleton<HttpClient>();
    }
}
