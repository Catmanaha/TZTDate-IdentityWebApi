using MediatR;

public class GetUserRolesCommand : IRequest<IEnumerable<Role>>
{
    public int UserId { get; set; }
}
