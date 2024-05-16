using MediatR;

public class RevokeRefreshTokenCommand : IRequest
{
    public Guid Token { get; set; }
    public string RevokedByIp { get; set; }
    public int RefreshTokenReplacedById { get; set; }
    public int UserId { get; set; }
}
