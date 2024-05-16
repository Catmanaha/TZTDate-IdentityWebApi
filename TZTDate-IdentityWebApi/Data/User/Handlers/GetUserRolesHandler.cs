using MediatR;
using Microsoft.EntityFrameworkCore;
using TZTDate.IdentityWebApi.Data.User.Commands;
using TZTDate.IdentityWebApi.Data.User.Models;
using TZTDate.IdentityWebApi.Extensions;

namespace TZTDate.IdentityWebApi.Data.User.Handlers;

public class GetUserRolesHandler : IRequestHandler<GetUserRolesCommand, IEnumerable<Role>>
{
    private readonly TZTDateDbContext context;
    public GetUserRolesHandler(TZTDateDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Role>> Handle(GetUserRolesCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users
        .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
        .FirstOrDefaultAsync(u => u.Id == request.UserId);

        if (user == null)
        {
            throw new EntityNotFoundException("User not found");
        }

        var roles = user.UserRoles.Select(ur => ur.Role).ToList();
        return roles;
    }
}
