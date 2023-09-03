using AutoMapper;
using FluentValidation;
using MediatR;
using VSAchitecture.Api.Data;

namespace VSAchitecture.Api.Features.Parents.AddAParent;

public record AddAParentCommand(
    string FirstName, 
    string LastName,
    string OtherNames,
    string Nationality,
    string ImageUrl,
    string Email) : IRequest<Guid>;

public class AddAParentCommandValidator : AbstractValidator<AddAParentCommand>
{
    public AddAParentCommandValidator()
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

public class AddAParentCommandHandler : IRequestHandler<AddAParentCommand, Guid>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<AddAParentCommandHandler> _logger;
    private readonly IMapper _mapper;

    public AddAParentCommandHandler(ApplicationDbContext dbContext, ILogger<AddAParentCommandHandler> logger, IMapper mapper)
    {
        _dbContext = dbContext;
        _logger = logger;
        _mapper = mapper;
    }
    
    public async Task<Guid> Handle(AddAParentCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddAParentCommandValidator();
        var validatorError = await validator.ValidateAsync(request);

        if (validatorError.Errors.Count > 0)
        {
            _logger.LogWarning("Request to add parent failed due to validation");
            throw new VSAchitecture.Api.Exceptions.ValidationException(validatorError);
        }

        var parent = _mapper.Map<Parent>(request);
        var result = _dbContext.Parents.Add(parent);
        
        await _dbContext.SaveChangesAsync();

        return parent.Id;
    }
}

public class CommandMapping : Profile
{
    public CommandMapping()
    {
        CreateMap<AddAParentCommand, Parent>();
    }
}