using System.IdentityModel.Tokens.Jwt;
using MediatR;
using TZTDate.IdentityWebApi.Data.Token.Commands;

namespace TZTDate.IdentityWebApi.Data.Token.Handlers;

public class ReadTokenHandler : IRequestHandler<ReadTokenCommand, JwtSecurityToken>
{
    public async Task<JwtSecurityToken> Handle(ReadTokenCommand request, CancellationToken cancellationToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var securityToken = handler.ReadJwtToken(request.AccessToken);

        return securityToken;
    }
}
