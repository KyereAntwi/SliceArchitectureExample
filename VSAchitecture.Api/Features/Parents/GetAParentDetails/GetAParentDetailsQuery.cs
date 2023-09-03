using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSAchitecture.Api.Data;
using VSAchitecture.Api.Exceptions;
using VSAchitecture.Api.Features.Parents.GetAllParents;

namespace VSAchitecture.Api.Features.Parents.GetAParentDetails;

public record GetAParentDetailsQuery(Guid Id) : IRequest<GetAParentDetailsResponse>;

public class GetAParentDetailsQueryHandler : IRequestHandler<GetAParentDetailsQuery, GetAParentDetailsResponse>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAParentDetailsQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<GetAParentDetailsResponse> Handle(GetAParentDetailsQuery request, CancellationToken cancellationToken)
    {
        GetAParentDetailsResponse response = new GetAParentDetailsResponse();
        
        var existingParent = await _dbContext.Parents.Include(p => p.Students).FirstOrDefaultAsync(p => p.Id == request.Id);

        if (existingParent is null)
        {
            throw new NotFoundException("Parent with specified Id does not exist", nameof(Parent));
        }

        var parentDto = _mapper.Map<ParentDto>(existingParent);

        if (existingParent.Students.Any())
        {
            response.Children.AddRange(existingParent.Students.Select(s => s.StudentId));
        }

        response.Parent = parentDto;

        return response;
    }
}