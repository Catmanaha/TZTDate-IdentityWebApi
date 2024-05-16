using MediatR;
using TZTBank.Core.Data.DateUser.Dtos;

public class AddNewCommand : IRequest
{
    public UserRegisterDto? UserRegisterDto { get; set; }
}
