using MediatR;
using TZTDate_IdentityWebApi.Models;

namespace TZTDate_IdentityWebApi.MediatR.Token.Commands;

public class CreateRefreshTokenCommand : IRequest<RefreshToken>
{
    public int UserId { get; set; }
    public string CreatedByIp { get; set; }
}
