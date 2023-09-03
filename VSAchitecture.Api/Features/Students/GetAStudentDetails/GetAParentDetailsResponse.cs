using VSAchitecture.Api.Features.Students.GetAllStudents;

namespace VSAchitecture.Api.Features.Students.GetAStudentDetails;

public class GetAStudentDetailsResponse
{
    public StudentDto Student { get; set; } = new StudentDto();
    public List<Guid> Parents { get; set; } = new List<Guid>();
}