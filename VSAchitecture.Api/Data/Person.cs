namespace VSAchitecture.Api.Data;

public class Person
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = String.Empty;
    public string OtherNames { get; set; } = String.Empty;
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    public string Nationality { get; set; } = String.Empty;
    public string? ImageUrl { get; set; }
}