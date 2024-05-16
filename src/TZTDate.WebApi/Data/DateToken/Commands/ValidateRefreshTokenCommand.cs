using MediatR;
using TZTDate.Core.Data.DateToken.Responses;

public class ValidateRefreshTokenCommand : IRequest<RefreshTokenValidationResponse>
{
    public Guid Token { get; set; }
    public int UserId { get; set; }
}
