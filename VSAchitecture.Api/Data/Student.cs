namespace VSAchitecture.Api.Data;

public class Student : Person
{
    public DateTime DateOfBirth { get; set; }

    public ICollection<StudentParent> Parents { get; set; } = default!;
}