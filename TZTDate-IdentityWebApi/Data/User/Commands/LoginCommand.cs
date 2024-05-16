using MediatR;
using TZTDate.IdentityWebApi.Data.User.Dtos;
using TZTDate.IdentityWebApi.Data.User.Responses;

namespace TZTDate.IdentityWebApi.Data.User.Commands;

public class LoginCommand : IRequest<LoginResponse>
{
    public UserLoginDto? userLoginDto { get; set; }
}
