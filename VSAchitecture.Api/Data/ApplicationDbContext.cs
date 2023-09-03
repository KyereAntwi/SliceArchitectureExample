using Microsoft.EntityFrameworkCore;

namespace VSAchitecture.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Parent> Parents { get; set; } = default!;
    public DbSet<Student> Students { get; set; } = default!;
    public DbSet<StudentParent> StudentParents { get; set; } = default!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.Entity<Parent>().HasData(new Parent()
        {
            Id = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@email.com"
        });

        modelBuilder.Entity<Parent>().HasData(new Parent()
        {
            Id = new Guid("8245fe4a-d402-451c-b9ed-9c1a04247482"),
            FirstName = "William",
            LastName = "Smith",
            Email = "william.smith@email.com"
        });

        modelBuilder.Entity<Student>().HasData(new Student()
        {
            Id = new Guid("7245fe4a-d402-451c-b9ed-9c1a04247482"),
            FirstName = "Chalese",
            LastName = "Doe"
        });

        modelBuilder.Entity<Student>().HasData(new Student()
        {
            Id = new Guid("6245fe4a-d402-451c-b9ed-9c1a04247482"),
            FirstName = "Joyce",
            LastName = "Doe"
        });

        modelBuilder.Entity<Student>().HasData(new Student()
        {
            Id = new Guid("5245fe4a-d402-451c-b9ed-9c1a04247482"),
            FirstName = "Fredrick",
            LastName = "Smith"
        });

        modelBuilder.Entity<StudentParent>().HasData(new StudentParent()
        {
            Id = new Guid("9875fe4a-d402-451c-b9ed-9c1a04247482"),
            ParentId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
            StudentId = new Guid("5245fe4a-d402-451c-b9ed-9c1a04247482")
        });
        
        modelBuilder.Entity<StudentParent>().HasData(new StudentParent()
        {
            Id = new Guid("9995fe4a-d402-451c-b9ed-9c1a04247482"),
            ParentId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
            StudentId = new Guid("6245fe4a-d402-451c-b9ed-9c1a04247482")
        });
    }
}