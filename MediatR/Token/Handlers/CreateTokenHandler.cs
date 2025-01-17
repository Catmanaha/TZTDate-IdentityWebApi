using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TZTDate_IdentityWebApi.MediatR.Token.Commands;
using TZTDate_IdentityWebApi.Options;

namespace TZTDate_IdentityWebApi.MediatR.Token.Handlers;

public class CreateTokenHandler : IRequestHandler<CreateTokenCommand, string>
{
    private readonly JwtOption jwtOptions;

    public CreateTokenHandler(IOptionsSnapshot<JwtOption> options)
    {
        this.jwtOptions = options.Value;
    }

    public async Task<string> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
    {
        var securityKey = new SymmetricSecurityKey(this.jwtOptions.KeyInBytes);
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.Aes128CbcHmacSha256);

        var securityToken = new JwtSecurityToken(
            issuer: this.jwtOptions.Issuers.First(),
            audience: this.jwtOptions.Audience,
            request.Claims,
            expires: DateTime.Now.AddMinutes(this.jwtOptions.LifetimeInMinutes),
            signingCredentials: signingCredentials
        );

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var jwt = jwtSecurityTokenHandler.WriteToken(securityToken);

        return jwt;
    }
}
