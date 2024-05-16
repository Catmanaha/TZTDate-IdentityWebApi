using System.Security.Claims;
using MediatR;

namespace TZTDate.IdentityWebApi.Data.Token.Commands;

public class CreateTokenCommand : IRequest<string>
{
    public IEnumerable<Claim> Claims { get; set; }
}
