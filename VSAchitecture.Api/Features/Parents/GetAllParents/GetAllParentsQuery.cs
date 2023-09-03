using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSAchitecture.Api.Data;

namespace VSAchitecture.Api.Features.Parents.GetAllParents;

public record GetAllParentsQuery() : IRequest<List<ParentDto>>;

public class GetAllParentsQueryHandler : IRequestHandler<GetAllParentsQuery, List<ParentDto>>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllParentsQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<List<ParentDto>> Handle(GetAllParentsQuery request, CancellationToken cancellationToken)
    {
        var list = await _dbContext.Parents.OrderBy(p => p.LastName).ToListAsync();
        return _mapper.Map<List<ParentDto>>(list);
    }
}