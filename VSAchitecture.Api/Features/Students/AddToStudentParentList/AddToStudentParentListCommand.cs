using MediatR;
using VSAchitecture.Api.Data;
using VSAchitecture.Api.Exceptions;

namespace VSAchitecture.Api.Features.Students.AddToStudentParentList;

public record AddToStudentParentListCommand(Guid ParentId, Guid StudentId) : IRequest;

public class AddToStudentParentListCommandHandler : IRequestHandler<AddToStudentParentListCommand>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<AddToStudentParentListCommandHandler> _logger;

    public AddToStudentParentListCommandHandler(ApplicationDbContext dbContext, ILogger<AddToStudentParentListCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task Handle(AddToStudentParentListCommand request, CancellationToken cancellationToken)
    {
        var parent = await _dbContext.Parents.FindAsync(request.ParentId);

        if (parent is null)
        {
            _logger.LogWarning("Specified parent for operation does not exist");
            throw new NotFoundException("Specified parent does not exist", nameof(Parent));
        }
        
        var student = await _dbContext.Students.FindAsync(request.StudentId);

        if (student is null)
        {
            _logger.LogWarning("Specified student for operation does not exist");
            throw new NotFoundException("Specified student does not exist", nameof(Student));
        }

        StudentParent model = new StudentParent()
        {
            ParentId = request.ParentId,
            StudentId = request.StudentId
        };

        _dbContext.StudentParents.Add(model);
        await _dbContext.SaveChangesAsync();
    }
}