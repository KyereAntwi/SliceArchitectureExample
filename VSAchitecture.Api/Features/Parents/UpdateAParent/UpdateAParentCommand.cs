using AutoMapper;
using FluentValidation;
using MediatR;
using VSAchitecture.Api.Data;

namespace VSAchitecture.Api.Features.Parents.UpdateAParent;

public record UpdateAParentCommand(
    Guid Id,
    string FirstName, 
    string LastName,
    string OtherNames,
    string Nationality,
    string ImageUrl,
    string Email
    ) : IRequest;
    
public class UpdateAParentCommandValidator : AbstractValidator<UpdateAParentCommand>
{
    public UpdateAParentCommandValidator()
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

public class UpdateAParentCommandHandler : IRequestHandler<UpdateAParentCommand>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<UpdateAParentCommandHandler> _logger;
    private readonly IMapper _mapper;

    public UpdateAParentCommandHandler(ApplicationDbContext dbContext, ILogger<UpdateAParentCommandHandler> logger, IMapper mapper)
    {
        _dbContext = dbContext;
        _logger = logger;
        _mapper = mapper;
    }
    
    public async Task Handle(UpdateAParentCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateAParentCommandValidator();
        var validatorError = await validator.ValidateAsync(request);

        if (validatorError.Errors.Count > 0)
        {
            _logger.LogWarning("Request to update parent failed due to validation");
            throw new VSAchitecture.Api.Exceptions.ValidationException(validatorError);
        }

        var parent = _mapper.Map<Parent>(request);
        var result = _dbContext.Parents.Update(parent);
        
        await _dbContext.SaveChangesAsync();
    }
}

public class CommandMapping : Profile
{
    public CommandMapping()
    {
        CreateMap<UpdateAParentCommand, Parent>();
    }
}