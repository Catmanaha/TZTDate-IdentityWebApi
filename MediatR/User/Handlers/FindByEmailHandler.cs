using MediatR;
using Microsoft.EntityFrameworkCore;
using TZTDate_IdentityWebApi.Data;
using TZTDate_IdentityWebApi.MediatR.User.Commands;

namespace TZTDate_IdentityWebApi.MediatR.User.Handlers;

public class FindByEmailHandler : IRequestHandler<FindByEmailCommand, Models.User>
{
    private readonly TZTDateDbContext context;

    public FindByEmailHandler(TZTDateDbContext context)
    {
        this.context = context;
    }

    public async Task<Models.User> Handle(FindByEmailCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Email))
        {
            throw new NullReferenceException($"{nameof(request.Email)} cannot be empty");

        }

        var user = await context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == request.Email.ToLower());

        return user;
    }
}