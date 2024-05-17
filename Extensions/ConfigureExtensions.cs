using Microsoft.AspNetCore.Mvc;
using TZTDate_IdentityWebApi.Options;

namespace TZTDate_IdentityWebApi.Extensions;

public static class ConfigureExtensions
{
    public static void Configure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {

        serviceCollection.Configure<ApiOption>(configuration.GetSection("ApiOption"));
        serviceCollection.Configure<JwtOption>(configuration.GetSection("JwtOption"));
        serviceCollection.Configure<BlobOption>(configuration.GetSection("BlobOption"));
        serviceCollection.Configure<MongoOption>(configuration.GetSection("MongoOption"));
        serviceCollection.Configure<ApiBehaviorOptions>(
                options => options.SuppressModelStateInvalidFilter = true);
    }
}
