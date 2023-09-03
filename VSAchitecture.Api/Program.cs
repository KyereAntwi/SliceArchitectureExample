using VSAchitecture.Api;
using VSAchitecture.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vertical Slice Architecture Practice API");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCustomExceptionHandler();

app.UseCors("Open");

app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();