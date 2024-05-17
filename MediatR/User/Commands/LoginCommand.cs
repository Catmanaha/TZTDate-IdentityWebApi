using MediatR;
using TZTDate_IdentityWebApi.Dtos;
using TZTDate_IdentityWebApi.Responses;

namespace TZTDate_IdentityWebApi.MediatR.User.Commands;

public class LoginCommand : IRequest<LoginResponse>
{
    public UserLoginDto? userLoginDto { get; set; }
}
