using MediatR;

public class ValidateRefreshTokenCommand : IRequest<RefreshTokenValidationResponse>
{
    public Guid Token { get; set; }
    public int UserId { get; set; }
}
