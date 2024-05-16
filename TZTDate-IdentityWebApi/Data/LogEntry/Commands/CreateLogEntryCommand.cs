using MediatR;
using TZTDate.IdentityWebApi.Data.LogEntry.Models;

namespace TZTDate.IdentityWebApi.Data.LogEntry.Commands;

public class CreateLogEntryCommand : IRequest
{
    public Models.LogEntry LogEntry { get; set; }
}