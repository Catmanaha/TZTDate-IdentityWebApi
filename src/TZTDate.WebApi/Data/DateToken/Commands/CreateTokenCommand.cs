using System.Security.Claims;
using MediatR;

public class CreateTokenCommand : IRequest<string>
{
    public IEnumerable<Claim> Claims { get; set; }
}
