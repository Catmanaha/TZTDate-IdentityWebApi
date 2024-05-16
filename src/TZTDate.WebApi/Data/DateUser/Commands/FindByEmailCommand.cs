using MediatR;
using TZTDate.Core.Data.DateUser;

public class FindByEmailCommand : IRequest<User>
{
    public string Email { get; set; }
}
