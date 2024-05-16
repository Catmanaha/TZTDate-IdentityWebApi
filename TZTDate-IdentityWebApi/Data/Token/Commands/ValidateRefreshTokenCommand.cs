using MediatR;
using TZTDate.IdentityWebApi.Data.Token.Responses;

namespace TZTDate.IdentityWebApi.Data.Token.Commands;

public class ValidateRefreshTokenCommand : IRequest<RefreshTokenValidationResponse>
{
    public Guid Token { get; set; }
    public int UserId { get; set; }
}
