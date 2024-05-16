using MediatR;

namespace TZTDate.IdentityWebApi.Data.User.Commands;

public class FindByIdCommand : IRequest<Models.User>
{
    public int Id { get; set; }
}