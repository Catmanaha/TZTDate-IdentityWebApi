using MediatR;

namespace TZTDate_IdentityWebApi.MediatR.User.Commands;

public class FindByIdCommand : IRequest<Models.User>
{
    public int Id { get; set; }
}