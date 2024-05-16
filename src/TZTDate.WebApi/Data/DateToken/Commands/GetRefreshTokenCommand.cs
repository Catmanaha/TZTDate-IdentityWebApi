using MediatR;
using TZTDate.Core.Data.DateToken.Models;

public class GetRefreshTokenCommand : IRequest<RefreshToken>
{
    public Guid refershToken;
    public int userId;
}
