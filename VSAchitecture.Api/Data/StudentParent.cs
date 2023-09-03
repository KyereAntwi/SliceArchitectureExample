namespace VSAchitecture.Api.Data;

public class StudentParent
{
    public Guid Id { get; set; }
    
    public Guid StudentId { get; set; }
    public Student? Student { get; set; }

    public Guid ParentId { get; set; }
    public Parent? Parent { get; set; }
}