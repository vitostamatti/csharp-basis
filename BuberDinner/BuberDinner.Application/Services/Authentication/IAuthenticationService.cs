namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResponse Login(LoginRequest request);

    AuthenticationResponse Register(RegisterRequest request);
    
}

