using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSAchitecture.Api.Data;
using VSAchitecture.Api.Exceptions;
using VSAchitecture.Api.Features.Parents.GetAllParents;
using VSAchitecture.Api.Features.Parents.GetAParentDetails;
using VSAchitecture.Api.Features.Students.GetAllStudents;

namespace VSAchitecture.Api.Features.Students.GetAStudentDetails;

public record GetAStudentDetailsQuery(Guid Id) : IRequest<GetAStudentDetailsResponse>;

public class GetAStudentDetailsQueryHandler : IRequestHandler<GetAStudentDetailsQuery, GetAStudentDetailsResponse>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAStudentDetailsQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<GetAStudentDetailsResponse> Handle(GetAStudentDetailsQuery request, CancellationToken cancellationToken)
    {
        GetAStudentDetailsResponse response = new GetAStudentDetailsResponse();
        
        var existingStudent = await _dbContext.Students.Include(p => p.Parents).FirstOrDefaultAsync(p => p.Id == request.Id);

        if (existingStudent is null)
        {
            throw new NotFoundException("Student with specified Id does not exist", nameof(Student));
        }

        var studentDto = _mapper.Map<StudentDto>(existingStudent);

        if (existingStudent.Parents.Any())
        {
            response.Parents.AddRange(existingStudent.Parents.Select(s => s.ParentId));
        }

        response.Student = studentDto;

        return response;
    }
}