using MediatR;
using TZTDate.IdentityWebApi.Data.Token.Models;

namespace TZTDate.IdentityWebApi.Data.Token.Commands;

public class CreateRefreshTokenCommand : IRequest<RefreshToken>
{
    public int UserId { get; set; }
    public string CreatedByIp { get; set; }
}
