using MediatR;
using TZTDate.IdentityWebApi.Data.Token.Responses;
using TZTDate.IdentityWebApi.Data.User.Dtos;

namespace TZTDate.IdentityWebApi.Data.Token.Commands;

public class UpdateTokenCommand : IRequest<UpdateTokenResponse>
{
    public UpdateTokenDto UpdateTokenDto { get; set; }
}
