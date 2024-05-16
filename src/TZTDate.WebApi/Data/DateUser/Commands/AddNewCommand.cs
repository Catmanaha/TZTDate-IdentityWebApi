using MediatR;

public class AddNewCommand : IRequest
{
    public UserRegisterDto? UserRegisterDto { get; set; }
}
