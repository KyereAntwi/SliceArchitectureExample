using AutoMapper;
using VSAchitecture.Api.Data;

namespace VSAchitecture.Api.Features.Students.GetAllStudents;

public class StudentDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = String.Empty;
    public string OtherNames { get; set; } = String.Empty;
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    public string Nationality { get; set; } = String.Empty;
    public string? ImageUrl { get; set; }
    public string? Email { get; set; }
}

public class StudentDtoMapping : Profile
{
    public StudentDtoMapping()
    {
        CreateMap<Student, StudentDto>();
    }
}