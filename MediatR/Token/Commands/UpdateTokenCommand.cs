using MediatR;
using TZTDate_IdentityWebApi.Responses;
using TZTDate_IdentityWebApi.Dtos;

namespace TZTDate_IdentityWebApi.MediatR.Token.Commands;

public class UpdateTokenCommand : IRequest<UpdateTokenResponse>
{
    public UpdateTokenDto UpdateTokenDto { get; set; }
}
