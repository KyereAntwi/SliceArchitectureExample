using AutoMapper;
using FluentValidation;
using MediatR;
using VSAchitecture.Api.Data;

namespace VSAchitecture.Api.Features.Students.AddAStudent;

public record AddAStudentCommand(
    string FirstName, 
    string LastName,
    string OtherNames,
    string Nationality,
    string ImageUrl,
    string Email) : IRequest<Guid>;

public class AddAStudentCommandValidator : AbstractValidator<AddAStudentCommand>
{
    public AddAStudentCommandValidator()
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

public class AddAStudentCommandHandler : IRequestHandler<AddAStudentCommand, Guid>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<AddAStudentCommandHandler> _logger;
    private readonly IMapper _mapper;

    public AddAStudentCommandHandler(ApplicationDbContext dbContext, ILogger<AddAStudentCommandHandler> logger, IMapper mapper)
    {
        _dbContext = dbContext;
        _logger = logger;
        _mapper = mapper;
    }
    
    public async Task<Guid> Handle(AddAStudentCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddAStudentCommandValidator();
        var validatorError = await validator.ValidateAsync(request);

        if (validatorError.Errors.Count > 0)
        {
            throw new VSAchitecture.Api.Exceptions.ValidationException(validatorError);
            _logger.LogWarning("Request to add student failed due to validation");
        }

        var student = _mapper.Map<Student>(request);
        var result = _dbContext.Students.Add(student);
        
        await _dbContext.SaveChangesAsync();

        return student.Id;
    }
}

public class CommandMapping : Profile
{
    public CommandMapping()
    {
        CreateMap<AddAStudentCommand, Student>();
    }
}