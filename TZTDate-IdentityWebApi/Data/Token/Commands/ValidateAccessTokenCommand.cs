using MediatR;

namespace TZTDate.IdentityWebApi.Data.Token.Commands;

public class ValidateAccessTokenCommand : IRequest<bool>
{
    public string AccessToken { get; set; }
}
