using System.IdentityModel.Tokens.Jwt;
using MediatR;

namespace TZTDate_IdentityWebApi.MediatR.Token.Commands;

public class ReadTokenCommand : IRequest<JwtSecurityToken>
{
    public string AccessToken { get; set; }
}
