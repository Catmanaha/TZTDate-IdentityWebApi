namespace TZTDate.IdentityWebApi.Data.User.Dtos;

public class UpdateTokenDto
{
    public string AccessToken { get; set; }
    public Guid RefreshToken { get; set; }
    public string IpAddress { get; set; }
}