using MediatR;
using TZTDate.IdentityWebApi.Data.User.Dtos;

namespace TZTDate.IdentityWebApi.Data.User.Commands;

public class AddNewCommand : IRequest
{
    public UserRegisterDto? UserRegisterDto { get; set; }
}
