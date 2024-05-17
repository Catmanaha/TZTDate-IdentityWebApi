using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TZTDate_IdentityWebApi.MediatR.Token.Commands;
using TZTDate_IdentityWebApi.Options;

public class ValidateAccessTokenHandler : IRequestHandler<ValidateAccessTokenCommand, bool>
{
    private readonly JwtOption jwtOptions;

    public ValidateAccessTokenHandler(IOptionsSnapshot<JwtOption> options)
    {
        this.jwtOptions = options.Value;
    }
    public async Task<bool> Handle(ValidateAccessTokenCommand request, CancellationToken cancellationToken)
    {
        var handler = new JwtSecurityTokenHandler();

        var validationResult = await handler.ValidateTokenAsync(
            request.AccessToken,
            new TokenValidationParameters()
            {
                ValidateLifetime = false,
                IssuerSigningKey = new SymmetricSecurityKey(this.jwtOptions.KeyInBytes),

                ValidateAudience = true,
                ValidAudience = this.jwtOptions.Audience,

                ValidateIssuer = true,
                ValidIssuers = this.jwtOptions.Issuers,
            }
        );

        return validationResult.IsValid;
    }
}
