namespace TZTDate_IdentityWebApi.Responses;

public class LoginResponse
{
    public string AccessToken { get; set; }
    public Guid RefreshToken { get; set; }
}
