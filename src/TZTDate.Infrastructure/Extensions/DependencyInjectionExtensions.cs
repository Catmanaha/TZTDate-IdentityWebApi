using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TZTDate.Infrastructure.Services;
using TZTDate.Infrastructure.Services.Base;

namespace TZTDate.Infrastructure.Extensions;

public static class DependencyInjectionExtensions
{
    public static void Inject(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAzureBlobService, AzureBlobService>();
        serviceCollection.AddSingleton<HttpClient>();
    }
}
