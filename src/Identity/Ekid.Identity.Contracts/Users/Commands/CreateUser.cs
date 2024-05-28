using Ekid.Infrastructure.Messaging;

namespace Ekid.Identity.Contracts.Users.Commands;

//TODO permission
public record CreateUser(Guid TenantId, string FirstName, string LastName, string Login, string Password, string Email, string Role) : ICommand;