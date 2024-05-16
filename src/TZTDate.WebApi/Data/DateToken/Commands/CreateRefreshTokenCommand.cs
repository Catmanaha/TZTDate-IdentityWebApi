using MediatR;
using TZTDate.Core.Data.DateToken.Models;

public class CreateRefreshTokenCommand : IRequest<RefreshToken>
{
    public int UserId { get; set; }
    public string CreatedByIp { get; set; }
}
