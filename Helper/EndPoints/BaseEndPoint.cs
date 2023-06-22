using ErrorOr;
using InvBank.Web.Contracts.Authentication;

namespace InvBank.Web.Helper.EndPoints;

public class BaseEndPoint
{
    protected readonly ApiHelper _apiHelper;

    public BaseEndPoint(ApiHelper apiHelper)
    {
        _apiHelper = apiHelper;
    }

    public delegate Task<HttpResponseMessage> MakeFunc();

    protected async Task<ErrorOr<T>> MakeRequest<T>(MakeFunc apiCall)
    {
        HttpResponseMessage httpResponseMessage = await apiCall.Invoke();
        string result = await httpResponseMessage.Content.ReadAsStringAsync();

        return HandlerResponseFactory<T>.Create(httpResponseMessage.StatusCode).HandleResponse(result);
    }

    protected async Task<ErrorOr<T>> TryMakeRequest<T>(MakeFunc apiCall)
    {

        ErrorOr<T> result = await MakeRequest<T>(apiCall);

        if (!result.IsError)
        {
            return result;
        }

        var tokensResult = await MakeRequest<AuthenticationResult>(() => _apiHelper.DoGet("/auth/refresh_token?=" + "sds"));

        if (tokensResult.IsError)
        {
            return Error.Unexpected("Por favor faça o login para utilizar o serviço");
        }

        return await MakeRequest<T>(apiCall);

    }

}