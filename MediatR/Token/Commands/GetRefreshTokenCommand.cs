using MediatR;
using TZTDate_IdentityWebApi.Models;

namespace TZTDate_IdentityWebApi.MediatR.Token.Commands;

public class GetRefreshTokenCommand : IRequest<RefreshToken>
{
    public Guid refershToken;
    public int userId;
}
