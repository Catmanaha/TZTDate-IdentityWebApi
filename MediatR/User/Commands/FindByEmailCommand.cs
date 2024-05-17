using MediatR;

namespace TZTDate_IdentityWebApi.MediatR.User.Commands;

public class FindByEmailCommand : IRequest<Models.User>
{
    public string Email { get; set; }
}
