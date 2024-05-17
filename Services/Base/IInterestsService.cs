namespace TZTDate_IdentityWebApi.Services.Base;

public interface IInterestsService
{
    public Task<string> GetInterestsAsync(int userId);
    public Task SetInterestsAsync(int userId, IEnumerable<string> interests);
}
