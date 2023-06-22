using System.Text.Json;
using ErrorOr;
using InvBank.Web.Contracts;
using InvBank.Web.Contracts.Fund;

namespace InvBank.Web.Helper.EndPoints;

public class FundEndPoint : BaseEndPoint
{
    public FundEndPoint(AuthApiHelper apiHelper) : base(apiHelper)
    {
    }

    public async Task<ErrorOr<SimpleResponse>> CreateFund(CreateFundRequest request)
    {
        return await MakeRequest<SimpleResponse>(
            () => _apiHelper.DoPost($"/funds/create", JsonSerializer.Serialize(request))
        );
    }

    public async Task<ErrorOr<IEnumerable<FundResponse>>> GetInvestFundOfAccount(string accountIban)
    {
        return await MakeRequest<IEnumerable<FundResponse>>(
            () => _apiHelper.DoGet($"/funds?iban={accountIban}")
        );
    }

}