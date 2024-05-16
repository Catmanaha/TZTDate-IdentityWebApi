using MediatR;

namespace TZTDate.IdentityWebApi.Data.User.Commands;

public class GetUserRolesCommand : IRequest<IEnumerable<Models.Role>>
{
    public int UserId { get; set; }
}
