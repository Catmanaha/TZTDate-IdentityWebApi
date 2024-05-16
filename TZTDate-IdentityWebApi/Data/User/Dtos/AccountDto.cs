namespace TZTDate.IdentityWebApi.Data.User.Dtos;

public class AccountDto
{
    public Models.User User { get; set; }
    public List<string> ImageUris { get; set; }
}
