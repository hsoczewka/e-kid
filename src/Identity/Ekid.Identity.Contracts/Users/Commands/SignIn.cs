namespace Ekid.Identity.Contracts.Users.Commands;

public record SignIn(string Email, string Password) : ICommand;