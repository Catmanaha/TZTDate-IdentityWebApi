using MediatR;
using TZTDate.Core.Data.DateUser;

public class GetUserRolesCommand : IRequest<IEnumerable<Role>>
{
    public int UserId { get; set; }
}
