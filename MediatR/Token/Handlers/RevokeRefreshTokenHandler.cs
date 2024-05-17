using MediatR;
using TZTDate_IdentityWebApi.MediatR.Token.Commands;
using TZTDate_IdentityWebApi.Data;
using TZTDate_IdentityWebApi.MediatR.LogEntry.Commands;

namespace TZTDate_IdentityWebApi.MediatR.Token.Handlers;

public class RevokeRefreshTokenHandler : IRequestHandler<RevokeRefreshTokenCommand>
{
    private readonly ISender sender;
    private readonly TZTDateDbContext context;

    public RevokeRefreshTokenHandler(ISender sender, TZTDateDbContext context)
    {
        this.sender = sender;
        this.context = context;
    }
    public async Task Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var oldRefreshToken = await sender.Send(new GetRefreshTokenCommand
        {
            refershToken = request.Token,
            userId = request.UserId
        });

        if (oldRefreshToken == null)
        {
            throw new Exception("Invalid token.");
        }

        oldRefreshToken.Revoked = true;
        oldRefreshToken.RevokedByIp = request.RevokedByIp;
        oldRefreshToken.ReplacedByTokenId = request.RefreshTokenReplacedById;

        await this.context.SaveChangesAsync();

        var logEntry = new Models.LogEntry
        {
            EventDate = DateTime.UtcNow,
            EventIp = request.RevokedByIp,
            EventUserId = oldRefreshToken.UserId,
            EventType = "RefreshTokenRevoked"
        };

        await sender.Send(new CreateLogEntryCommand
        {
            LogEntry = logEntry
        });
    }
}
