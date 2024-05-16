using MediatR;
using TZTDate.Core.Data.DateUser;

public class FindByIdCommand : IRequest<User>
{
    public int Id { get; set; }
}