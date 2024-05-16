using System.IdentityModel.Tokens.Jwt;
using MediatR;

namespace TZTDate.IdentityWebApi.Data.Token.Commands;

public class ReadTokenCommand : IRequest<JwtSecurityToken>
{
    public string AccessToken { get; set; }
}
