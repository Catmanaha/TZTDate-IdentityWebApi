using MediatR;
using Microsoft.EntityFrameworkCore;
using TZTDate_IdentityWebApi.Data;
using TZTDate_IdentityWebApi.MediatR.User.Commands;

namespace TZTDate_IdentityWebApi.MediatR.User.Handlers;

public class FindByIdHandler : IRequestHandler<FindByIdCommand, Models.User>
{
    private readonly TZTDateDbContext context;
    public FindByIdHandler(TZTDateDbContext context)
    {
        this.context = context;

    }

    public async Task<Models.User> Handle(FindByIdCommand request, CancellationToken cancellationToken)
    {
        if (request.Id < 0)
        {
            throw new ArgumentOutOfRangeException($"{nameof(request.Id)} cannot be negative");
        }

        var user = await context.Users
                        .Include(u => u.Address)
                        .Include(u => u.Followers)
                        .Include(u => u.Followed)
                        .Include(u => u.UserRoles)
                        .FirstOrDefaultAsync(u => u.Id == request.Id);

        if (user is null)
        {
            throw new NullReferenceException("User not found");
        }

        return user;
    }
}