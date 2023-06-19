using System.Text.Json;
using ErrorOr;
using InvBank.Web.Contracts;
using InvBank.Web.Contracts.Deposit;
using InvBank.Web.Contracts.PropertyAccount;

namespace InvBank.Web.Helper.EndPoints;

public class PropertyAccountEndPoint : BaseEndPoint
{
    public PropertyAccountEndPoint(ApiHelper apiHelper) : base(apiHelper)
    {
    }
    
    public async Task<ErrorOr<SimpleResponse>> PayProperty(PayPropertyRequest request)
    {
        return await MakeRequest<SimpleResponse>
        (
            () => _apiHelper.DoPostAuth($"/properties/pay", JsonSerializer.Serialize(request))
        );
    }

    public async Task<ErrorOr<SimpleResponse>> CreatePropertyAccount(CreatePropertyAccountRequest request)
    {
        return await MakeRequest<SimpleResponse>
        (
            () => _apiHelper.DoPostAuth("/properties/create", JsonSerializer.Serialize(request))
        );
    }

    public async Task<ErrorOr<PropertyAccountResponse>> GetPropertyAccount(Guid id)
    {
        return await MakeRequest<PropertyAccountResponse>
        (
            () => _apiHelper.DoGetAuth($"/properties?id={id}")
        );
    }

    public async Task<ErrorOr<IEnumerable<PropertyAccountResponse>>> GetAllPropertyAccount(string accountIban)
    {
        return await MakeRequest<IEnumerable<PropertyAccountResponse>>
        (
            () => _apiHelper.DoGetAuth($"/properties/all?iban={accountIban}")
        );
    }

    public async Task<ErrorOr<IEnumerable<PropertyAccountResponse>>> UpdatePropertyAccount(Guid id, UpdatePropertyAccountRequest request)
    {
        return await MakeRequest<IEnumerable<PropertyAccountResponse>>
        (
            () => _apiHelper.DoUpdateAuth($"/properties/update?id={id}", JsonSerializer.Serialize(request))
        );
    }

    public async Task<ErrorOr<SimpleResponse>> DeletePropertyAccount(Guid id)
    {
        return await MakeRequest<SimpleResponse>
        (
            () => _apiHelper.DoDeleteAuth($"/properties/delete?id={id}")
        );
    }

}