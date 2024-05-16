using MediatR;

public class GetRefreshTokenCommand : IRequest<RefreshToken>
{
    public Guid refershToken;
    public int userId;
}
