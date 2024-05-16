using MediatR;

public class FindByEmailCommand : IRequest<User>
{
    public string Email { get; set; }
}
