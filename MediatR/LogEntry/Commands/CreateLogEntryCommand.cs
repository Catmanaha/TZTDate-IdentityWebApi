using MediatR;

namespace TZTDate_IdentityWebApi.MediatR.LogEntry.Commands;

public class CreateLogEntryCommand : IRequest
{
    public Models.LogEntry LogEntry { get; set; }
}