namespace APIBoilerplate.Contracts.Authentication;

public record LogInRequest(
    string Email,
    string Password);