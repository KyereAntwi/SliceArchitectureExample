using AutoMapper;
using FluentValidation;
using MediatR;
using VSAchitecture.Api.Data;

namespace VSAchitecture.Api.Features.Students.UpdateAStudent;

public record UpdateAStudentCommand(
    Guid Id,
    string FirstName, 
    string LastName,
    string OtherNames,
    string Nationality,
    string ImageUrl,
    string Email
    ) : IRequest;
    
public class UpdateAStudentCommandValidator : AbstractValidator<UpdateAStudentCommand>
{
    public UpdateAStudentCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("{PropertyName} field is required")
            .NotNull();
        
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("{PropertyName} field is required")
            .NotNull();
        
        RuleFor(x => x.Nationality)
            .NotEmpty().WithMessage("{PropertyName} field is required")
            .NotNull();
    }
}

public class UpdateAStudentCommandHandler : IRequestHandler<UpdateAStudentCommand>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<UpdateAStudentCommandHandler> _logger;
    private readonly IMapper _mapper;

    public UpdateAStudentCommandHandler(ApplicationDbContext dbContext, ILogger<UpdateAStudentCommandHandler> logger, IMapper mapper)
    {
        _dbContext = dbContext;
        _logger = logger;
        _mapper = mapper;
    }
    
    public async Task Handle(UpdateAStudentCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateAStudentCommandValidator();
        var validatorError = await validator.ValidateAsync(request);

        if (validatorError.Errors.Count > 0)
        {
            throw new VSAchitecture.Api.Exceptions.ValidationException(validatorError);
            _logger.LogWarning("Request to update student failed due to validation");
        }

        var student = _mapper.Map<Student>(request);
        var result = _dbContext.Students.Update(student);
        
        await _dbContext.SaveChangesAsync();
    }
}

public class CommandMapping : Profile
{
    public CommandMapping()
    {
        CreateMap<UpdateAStudentCommand, Parent>();
    }
}