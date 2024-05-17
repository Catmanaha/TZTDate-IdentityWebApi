using System.IdentityModel.Tokens.Jwt;
using MediatR;
using TZTDate_IdentityWebApi.MediatR.Token.Commands;

namespace TZTDate_IdentityWebApi.MediatR.Token.Handlers;

public class ReadTokenHandler : IRequestHandler<ReadTokenCommand, JwtSecurityToken>
{
    public async Task<JwtSecurityToken> Handle(ReadTokenCommand request, CancellationToken cancellationToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var securityToken = handler.ReadJwtToken(request.AccessToken);

        return securityToken;
    }
}
