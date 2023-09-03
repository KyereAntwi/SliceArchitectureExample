using MediatR;
using VSAchitecture.Api.Data;
using VSAchitecture.Api.Exceptions;

namespace VSAchitecture.Api.Features.Students.AddAStudent;

public record DeleteAStudentCommand(Guid Id) : IRequest;

public class DeleteAStudentCommandHandler : IRequestHandler<DeleteAStudentCommand>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<DeleteAStudentCommandHandler> _logger;

    public DeleteAStudentCommandHandler(ApplicationDbContext dbContext, ILogger<DeleteAStudentCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task Handle(DeleteAStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _dbContext.Students.FindAsync(request.Id);

        if (student is null)
        {
            throw new NotFoundException("Specified student Id does not exist", nameof(Student));
        }

        _dbContext.Students.Remove(student);
        await _dbContext.SaveChangesAsync();
    }
}