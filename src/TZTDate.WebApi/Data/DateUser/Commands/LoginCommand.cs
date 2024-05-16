using MediatR;

public class LoginCommand : IRequest<LoginResponse>
{
    public UserLoginDto? userLoginDto { get; set; }
}
