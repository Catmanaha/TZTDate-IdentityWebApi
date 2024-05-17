using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TZTDate_IdentityWebApi.Models;

public class UserInterests
{
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    public IEnumerable<string> Interests { get; set; }
    public int UserId { get; set; }
}
