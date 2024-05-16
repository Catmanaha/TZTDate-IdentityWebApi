using MediatR;

public class ValidateAccessTokenCommand : IRequest<bool>
{
    public string AccessToken { get; set; }
}
