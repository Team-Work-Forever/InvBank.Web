using System.Text.Json;
using ErrorOr;
using InvBank.Web.Contracts;
using InvBank.Web.Contracts.Account;

namespace InvBank.Web.Helper.EndPoints;

public class AccountEndPoint : BaseEndPoint
{
    public AccountEndPoint(ApiHelper apiHelper) : base(apiHelper)
    {
    }

    public async Task<ErrorOr<AccountResponse>> CreateAccount(CreateAccountRequest request)
    {
        return await MakeRequest<AccountResponse>(() => _apiHelper.DoPostAuth($"/accounts/create", JsonSerializer.Serialize(request)));
    }

    public async Task<ErrorOr<AccountResponse>> GetAccount(string iban)
    {
        return await MakeRequest<AccountResponse>(() => _apiHelper.DoGetAuth($"/accounts?iban={iban}"));
    }

    public async Task<ErrorOr<IEnumerable<AccountResponse>>> GetAllAccount()
    {
        return await MakeRequest<IEnumerable<AccountResponse>>(() => _apiHelper.DoGetAuth($"/accounts/all"));
    }

    public async Task<ErrorOr<SimpleResponse>> DeleteAccount(string iban)
    {
        return await MakeRequest<SimpleResponse>(
            () => _apiHelper.DoDeleteAuth($"/accounts/delete?iban={iban}"));
    }

}