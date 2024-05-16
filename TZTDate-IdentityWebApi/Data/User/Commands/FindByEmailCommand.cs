using MediatR;

namespace TZTDate.IdentityWebApi.Data.User.Commands;

public class FindByEmailCommand : IRequest<Models.User>
{
    public string Email { get; set; }
}
