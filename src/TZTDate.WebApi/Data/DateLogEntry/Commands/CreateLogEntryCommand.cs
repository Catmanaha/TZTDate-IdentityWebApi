using MediatR;
using TZTDate.Core.Data.DateLogEntry.Models;

public class CreateLogEntryCommand : IRequest
{
    public LogEntry LogEntry { get; set; }
}
