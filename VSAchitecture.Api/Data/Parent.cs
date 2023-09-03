namespace VSAchitecture.Api.Data;

public class Parent : Person
{
    public string? Email { get; set; }
    public string? MobileTelephone { get; set; }
    public string? HomeTelephone { get; set; }
    public string? Address { get; set; }

    public ICollection<StudentParent> Students { get; set; } = default!;
}