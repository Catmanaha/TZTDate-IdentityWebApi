using MediatR;

namespace TZTDate.IdentityWebApi.Data.User.Commands;

public class FollowActionCommand : IRequest
{
    public int currentUserId { get; set; }
    public int userToActionId { get; set; }
}