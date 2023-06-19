using System.Text.Json;
using ErrorOr;
using InvBank.Web.Contracts;
using InvBank.Web.Contracts.Deposit;

namespace InvBank.Web.Helper.EndPoints;

public class DepositEndPoint : BaseEndPoint
{
    public DepositEndPoint(ApiHelper apiHelper) : base(apiHelper)
    {
    }

    public async Task<ErrorOr<SimpleResponse>> PayDeposit(PayDepositRequest request)
    {
        return await MakeRequest<SimpleResponse>
        (
            () => _apiHelper.DoPostAuth($"/deposits/pay", JsonSerializer.Serialize(request))
        );
    }

    public async Task<ErrorOr<DepositResponse>> GetDeposit(Guid id)
    {
        return await MakeRequest<DepositResponse>
        (
            () => _apiHelper.DoGetAuth($"/deposits?id={id}")
        );
    }

    public async Task<ErrorOr<IEnumerable<DepositResponse>>> GetAllDeposit(string accountIban)
    {
        return await MakeRequest<IEnumerable<DepositResponse>>
        (
            () => _apiHelper.DoGetAuth($"/deposits/all?accountIban={accountIban}")
        );
    }

    public async Task<ErrorOr<SimpleResponse>> CreateDeposit(CreateDepositRequest request)
    {
        return await MakeRequest<SimpleResponse>
        (
            () => _apiHelper.DoPostAuth($"/deposits/create", JsonSerializer.Serialize(request))
        );
    }

    public async Task<ErrorOr<IEnumerable<DepositResponse>>> UpdateDeposit(Guid depositId, UpdateDepositRequest request)
    {
        return await MakeRequest<IEnumerable<DepositResponse>>
        (
            () => _apiHelper.DoUpdateAuth($"/deposits/update?iban={depositId}", JsonSerializer.Serialize(request))
        );
    }

    public async Task<ErrorOr<SimpleResponse>> DeleteDeposit(Guid depositId)
    {
        return await MakeRequest<SimpleResponse>
        (
            () => _apiHelper.DoDeleteAuth($"/deposits/delete?depositIban={depositId}")
        );
    }

}