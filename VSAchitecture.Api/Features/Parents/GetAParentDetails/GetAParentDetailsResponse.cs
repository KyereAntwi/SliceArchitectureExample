using VSAchitecture.Api.Features.Parents.GetAllParents;

namespace VSAchitecture.Api.Features.Parents.GetAParentDetails;

public class GetAParentDetailsResponse
{
    public ParentDto Parent { get; set; } = new ParentDto();
    public List<Guid> Children { get; set; } = new List<Guid>();
}