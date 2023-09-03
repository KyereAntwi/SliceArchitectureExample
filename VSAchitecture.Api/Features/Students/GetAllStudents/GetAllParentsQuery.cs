using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSAchitecture.Api.Data;

namespace VSAchitecture.Api.Features.Students.GetAllStudents;

public record GetAllStudentsQuery() : IRequest<List<StudentDto>>;

public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<StudentDto>>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllStudentsQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<List<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var list = await _dbContext.Students.OrderBy(p => p.LastName).ToListAsync();
        return _mapper.Map<List<StudentDto>>(list);
    }
}