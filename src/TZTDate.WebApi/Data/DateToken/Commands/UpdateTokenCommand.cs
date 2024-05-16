using MediatR;
using TZTDate.Core.Data.DateToken.Responses;
using TZTDate.Core.Data.DateUser.Dtos;

public class UpdateTokenCommand : IRequest<UpdateTokenResponse>
{
    public UpdateTokenDto UpdateTokenDto { get; set; }
}
