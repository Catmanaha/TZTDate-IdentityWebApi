using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TZTDate_IdentityWebApi.Options;

namespace TZTDate_IdentityWebApi.Extensions;

public static class AuthenticationExtension
{
    public static void InitAuthentication(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection("JwtOption").Get<JwtOption>();

        serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(jwtOptions.KeyInBytes),

                    ValidateLifetime = true,

                    ValidateAudience = true,
                    ValidAudience = jwtOptions.Audience,

                    ValidateIssuer = true,
                    ValidIssuers = jwtOptions.Issuers,
                };
            });
    }
}
