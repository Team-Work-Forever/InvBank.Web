using Blazored.LocalStorage;
using InvBank.Web.Helper.Authentication;

namespace InvBank.Web.Helper;

public class AuthApiHelper : IApiCaller
{
    private readonly ApiHelper _apiHelper;
    private readonly ILocalStorageService _localStorage;

    public AuthApiHelper(ApiHelper apiHelper, ILocalStorageService localStorage)
    {
        _apiHelper = apiHelper;
        _localStorage = localStorage;
    }

    private async Task<IDictionary<string, string>> TryAddAuthorizationAsync(IDictionary<string, string>? headers)
    {

        if (headers is null)
        {
            headers = new Dictionary<string, string>();
        }

        headers.Add("Authorization", await _localStorage.GetItemAsStringAsync(CookieValue.AccessToken));
        return headers;

    }

    public async Task<HttpResponseMessage> DoDelete(string endpoint, IDictionary<string, string>? headers)
    {
        return await _apiHelper.DoDelete(endpoint, await TryAddAuthorizationAsync(headers));
    }

    public async Task<HttpResponseMessage> DoGet(string endpoint, IDictionary<string, string>? headers)
    {
        return await _apiHelper.DoGet(endpoint, await TryAddAuthorizationAsync(headers));
    }

    public async Task<HttpResponseMessage> DoPost(string endpoint, string payload, IDictionary<string, string>? headers)
    {
        return await _apiHelper.DoPost(endpoint, payload, await TryAddAuthorizationAsync(headers));
    }

    public async Task<HttpResponseMessage> DoPut(string endpoint, string payload, IDictionary<string, string>? headers)
    {
        return await _apiHelper.DoPut(endpoint, payload, await TryAddAuthorizationAsync(headers));
    }
}