using MediatR;
using VSAchitecture.Api.Data;
using VSAchitecture.Api.Exceptions;

namespace VSAchitecture.Api.Features.Parents.DeleteAParent;

public record DeleteAParentCommand(Guid Id) : IRequest;

public class DeleteAParentCommandHandler : IRequestHandler<DeleteAParentCommand>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<DeleteAParentCommandHandler> _logger;

    public DeleteAParentCommandHandler(ApplicationDbContext dbContext, ILogger<DeleteAParentCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task Handle(DeleteAParentCommand request, CancellationToken cancellationToken)
    {
        var parent = await _dbContext.Parents.FindAsync(request.Id);

        if (parent is null)
        {
            throw new NotFoundException("Specified parent Id does not exist", nameof(Parent));
        }

        _dbContext.Parents.Remove(parent);
        await _dbContext.SaveChangesAsync();
    }
}