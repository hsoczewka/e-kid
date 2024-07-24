using Ekid.Web.ApiClient;
using Ekid.Web.Users.Contracts;

namespace Ekid.Web.Users;

public interface IUserAccountClient
{
    Task<ApiResponse> SignUpAsync(SignUp request);
}

public class UserAccountClient : IUserAccountClient
{
    public Task<ApiResponse> SignUpAsync(SignUp request)
    {
        throw new NotImplementedException();
    }
}