using MediatR;
using Microsoft.Extensions.Options;

public class CreateRefreshTokenHandler : IRequestHandler<CreateRefreshTokenCommand, RefreshToken>
{
    private readonly JwtOption jwtOptions;
    private readonly TZTDateDbContext context;

    public CreateRefreshTokenHandler(IOptionsSnapshot<JwtOption> options, TZTDateDbContext context)
    {
        this.jwtOptions = options.Value;
        this.context = context;
    }

    public async Task<RefreshToken> Handle(CreateRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = new RefreshToken
        {
            UserId = request.UserId,
            Token = Guid.NewGuid(),
            ExpiryDate = DateTime.UtcNow.AddHours(jwtOptions.RefreshTokenLifetimeInHours),
            CreatedDate = DateTime.UtcNow,
            CreatedByIp = request.CreatedByIp,
            Revoked = false,
            RevokedByIp = string.Empty,
        };

        await this.context.RefreshTokens.AddAsync(refreshToken);
        await this.context.SaveChangesAsync();

        return refreshToken;
    }
}
