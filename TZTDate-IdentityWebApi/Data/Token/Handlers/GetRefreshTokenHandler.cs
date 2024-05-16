using MediatR;
using Microsoft.EntityFrameworkCore;
using TZTDate.IdentityWebApi.Data.Token.Commands;
using TZTDate.IdentityWebApi.Data.Token.Models;

namespace TZTDate.IdentityWebApi.Data.Token.Handlers;

public class GetRefreshTokenHandler : IRequestHandler<GetRefreshTokenCommand, RefreshToken>
{
    private readonly TZTDateDbContext context;
    public GetRefreshTokenHandler(TZTDateDbContext context)
    {
        this.context = context;

    }
    public async Task<RefreshToken> Handle(GetRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        return await context.RefreshTokens.FirstOrDefaultAsync(o => o.Token == request.refershToken && o.UserId == request.userId);
    }
}