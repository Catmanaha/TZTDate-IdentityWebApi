using MediatR;

namespace TZTDate_IdentityWebApi.MediatR.Token.Commands;

public class ValidateAccessTokenCommand : IRequest<bool>
{
    public string AccessToken { get; set; }
}
