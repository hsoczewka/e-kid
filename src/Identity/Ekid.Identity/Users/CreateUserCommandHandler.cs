using Ekid.Identity.Contracts.Users.Commands;
using Ekid.Infrastructure.Messaging;

namespace Ekid.Identity.Users;

public class CreateUserCommandHandler : ICommandHandler<CreateUser>
{
    private readonly UserRepository _userRepository;

    public CreateUserCommandHandler(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task HandleAsync(CreateUser command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(command.Email, cancellationToken);
        if (existingUser is not null)
            throw new Exception("User with given email already exists.");

        //if role employee check employees table for existence
        //employee can not belong to many tenants
        //user can belong to many tenants
        //admin can belong to many tenants
        
        //TODO apply migration
        var user = new User(id: Guid.NewGuid(), tenantId: command.TenantId, firstName: command.FirstName,
            lastName: command.LastName, login: command.Login, password: command.Password, email: command.Email,
            role: new UserRole(command.Role), isActive: true);

        await _userRepository.AddAsync(user, cancellationToken);
    }
}