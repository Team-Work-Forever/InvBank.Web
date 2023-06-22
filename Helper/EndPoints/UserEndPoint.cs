using ErrorOr;
using InvBank.Web.Contracts;
using InvBank.Web.Contracts.Users;

namespace InvBank.Web.Helper.EndPoints;

public class UserEndPoint : BaseEndPoint
{
    public UserEndPoint(AuthApiHelper apiHelper) : base(apiHelper)
    {
    }

    public async Task<ErrorOr<IEnumerable<UserResponse>>> GetAllUsers()
    {
        return await MakeRequest<IEnumerable<UserResponse>>(
            () => _apiHelper.DoGet("/users/clients")
        );
    }

}