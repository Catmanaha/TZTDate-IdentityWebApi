using MediatR;
using TZTDate_IdentityWebApi.Responses;

namespace TZTDate_IdentityWebApi.MediatR.Token.Commands;

public class ValidateRefreshTokenCommand : IRequest<RefreshTokenValidationResponse>
{
    public Guid Token { get; set; }
    public int UserId { get; set; }
}
