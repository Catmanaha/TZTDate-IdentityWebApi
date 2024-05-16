using MediatR;
using TZTBank.Core.Data.DateUser.Dtos;
using TZTDate.Core.Data.DateUser.Responses;

public class LoginCommand : IRequest<LoginResponse>
{
    public UserLoginDto? userLoginDto { get; set; }
}
