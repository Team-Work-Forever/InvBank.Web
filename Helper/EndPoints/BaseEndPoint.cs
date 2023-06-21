using ErrorOr;

namespace InvBank.Web.Helper.EndPoints;

public class BaseEndPoint
{
    protected readonly ApiHelper _apiHelper;

    public BaseEndPoint(ApiHelper apiHelper)
    {
        _apiHelper = apiHelper;
    }

    protected delegate Task<HttpResponseMessage> MakeFunc();

    protected async Task<ErrorOr<T>> MakeRequest<T>(MakeFunc t)
    {
        HttpResponseMessage httpResponseMessage = await t.Invoke();
        string result = await httpResponseMessage.Content.ReadAsStringAsync();

        return HandlerResponseFactory<T>.Create(httpResponseMessage.StatusCode).HandleResponse(result);
    }

}