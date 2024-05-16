using MediatR;

public class CreateLogEntryHandler : IRequestHandler<CreateLogEntryCommand>
{
    private readonly TZTDateDbContext context;

    public CreateLogEntryHandler(TZTDateDbContext context)
    {
        this.context = context;
    }
    public async Task Handle(CreateLogEntryCommand request, CancellationToken cancellationToken)
    {
        await this.context.LogEntries.AddAsync(request.LogEntry);
        await this.context.SaveChangesAsync();
    }
}
