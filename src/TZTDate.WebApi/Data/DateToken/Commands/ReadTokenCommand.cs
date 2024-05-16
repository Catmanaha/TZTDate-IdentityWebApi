using System.IdentityModel.Tokens.Jwt;
using MediatR;

public class ReadTokenCommand : IRequest<JwtSecurityToken>
{
    public string AccessToken { get; set; }
}
