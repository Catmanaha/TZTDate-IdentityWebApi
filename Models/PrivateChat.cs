namespace TZTDate_IdentityWebApi.Models;

public class PrivateChat
{
    public int Id { get; set; }
    public string PrivateChatHashName { get; set; }
    public List<Message>? Messages { get; set; }
}