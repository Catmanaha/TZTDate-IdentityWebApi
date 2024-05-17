namespace TZTDate_IdentityWebApi.Dtos;

public class UpdateTokenDto
{
    public string AccessToken { get; set; }
    public Guid RefreshToken { get; set; }
    public string IpAddress { get; set; }
}