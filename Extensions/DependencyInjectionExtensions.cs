using TZTDate_IdentityWebApi.Filters;
using TZTDate_IdentityWebApi.Middlewares;
using TZTDate_IdentityWebApi.Services;
using TZTDate_IdentityWebApi.Services.Base;

namespace TZTDate_IdentityWebApi.Extensions;

public static class DependencyInjectionExtensions
{
    public static void Inject(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAzureBlobService, AzureBlobService>();
        serviceCollection.AddScoped<IInterestsService, InterestsMongoService>();

        serviceCollection.AddTransient<ExceptionHandlingMiddleware>();
        serviceCollection.AddScoped<ValidationFilterAttribute>();

        serviceCollection.AddSingleton<HttpClient>();
    }
}
