using System.Security.Claims;
using MediatR;

namespace TZTDate_IdentityWebApi.MediatR.Token.Commands;

public class CreateTokenCommand : IRequest<string>
{
    public IEnumerable<Claim> Claims { get; set; }
}
