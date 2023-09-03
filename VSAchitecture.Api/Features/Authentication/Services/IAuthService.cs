using VSAchitecture.Api.Features.Authentication.Models;

namespace VSAchitecture.Api.Features.Authentication.Services;

public interface IAuthService
{
    Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
}