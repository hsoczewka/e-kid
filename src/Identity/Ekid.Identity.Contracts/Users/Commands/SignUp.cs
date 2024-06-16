namespace Ekid.Identity.Contracts.Users.Commands;

public record SignUp(string Login, string Password, string Email) : ICommand;