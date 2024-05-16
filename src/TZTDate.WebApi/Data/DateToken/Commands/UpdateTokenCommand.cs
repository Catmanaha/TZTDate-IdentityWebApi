using MediatR;

public class UpdateTokenCommand : IRequest<UpdateTokenResponse>
{
    public UpdateTokenDto UpdateTokenDto { get; set; }
}
