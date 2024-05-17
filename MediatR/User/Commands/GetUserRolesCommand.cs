using MediatR;

namespace TZTDate_IdentityWebApi.MediatR.User.Commands;

public class GetUserRolesCommand : IRequest<IEnumerable<Models.Role>>
{
    public int UserId { get; set; }
}
