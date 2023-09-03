using AutoMapper;
using VSAchitecture.Api.Data;

namespace VSAchitecture.Api.Features.Parents.GetAllParents;

public class ParentDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = String.Empty;
    public string OtherNames { get; set; } = String.Empty;
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    public string Nationality { get; set; } = String.Empty;
    public string? ImageUrl { get; set; }
}

public class ParentDtoMapping : Profile
{
    public ParentDtoMapping()
    {
        CreateMap<Parent, ParentDto>();
    }
}