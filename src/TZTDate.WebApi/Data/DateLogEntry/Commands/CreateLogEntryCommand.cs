using MediatR;

public class CreateLogEntryCommand : IRequest
{
    public LogEntry LogEntry { get; set; }
}
