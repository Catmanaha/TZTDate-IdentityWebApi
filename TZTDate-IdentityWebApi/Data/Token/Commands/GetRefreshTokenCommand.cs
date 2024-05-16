using MediatR;
using TZTDate.IdentityWebApi.Data.Token.Models;

namespace TZTDate.IdentityWebApi.Data.Token.Commands;

public class GetRefreshTokenCommand : IRequest<RefreshToken>
{
    public Guid refershToken;
    public int userId;
}
