using MediatR;
using Microsoft.EntityFrameworkCore;
using VSAchitecture.Api.Data;
using VSAchitecture.Api.Exceptions;

namespace VSAchitecture.Api.Features.Students.RemoveParentFromList;

public record RemoveParentFromListCommand(Guid ParentId, Guid StudentId) : IRequest;

public class RemoveParentFromListCommandHandler : IRequestHandler<RemoveParentFromListCommand>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<RemoveParentFromListCommandHandler> _logger;

    public RemoveParentFromListCommandHandler(ApplicationDbContext dbContext, ILogger<RemoveParentFromListCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task Handle(RemoveParentFromListCommand request, CancellationToken cancellationToken)
    {
        var existing = await _dbContext.StudentParents.FirstOrDefaultAsync(sp => sp.StudentId == request.StudentId && sp.ParentId == request.ParentId);

        if (existing is null)
        {
            _logger.LogWarning("Specified data for operation does not exist");
            throw new NotFoundException("Specified data does not exist", nameof(StudentParent));
        }

        _dbContext.StudentParents.Remove(existing);
        await _dbContext.SaveChangesAsync();
    }
}