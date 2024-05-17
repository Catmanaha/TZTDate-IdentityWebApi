using MediatR;
using TZTDate_IdentityWebApi.Dtos;

namespace TZTDate_IdentityWebApi.MediatR.User.Commands;

public class AddNewCommand : IRequest
{
    public UserRegisterDto? UserRegisterDto { get; set; }
}
