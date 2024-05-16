using MediatR;
using Microsoft.EntityFrameworkCore;

public class FindByEmailHandler : IRequestHandler<FindByEmailCommand, User>
{
    private readonly TZTDateDbContext context;

    public FindByEmailHandler(TZTDateDbContext context)
    {
        this.context = context;
    }

    public async Task<User> Handle(FindByEmailCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Email))
        {
            throw new NullReferenceException($"{nameof(request.Email)} cannot be empty");

        }

        var user = await context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == request.Email.ToLower());

        return user;
    }
}