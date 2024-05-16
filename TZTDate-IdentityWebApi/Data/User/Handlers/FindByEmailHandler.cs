using MediatR;
using Microsoft.EntityFrameworkCore;
using TZTDate.IdentityWebApi.Data.User.Commands;

namespace TZTDate.IdentityWebApi.Data.User.Handlers;

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