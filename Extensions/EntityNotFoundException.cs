namespace TZTDate_IdentityWebApi.Extensions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string message) : base(message) { }
}
