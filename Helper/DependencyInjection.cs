using InvBank.Web.Helper.EndPoints;

namespace InvBank.Web.Helper;

public static class DependencyInjection
{

    public static IServiceCollection AddHelper(this IServiceCollection services)
    {

        services.AddScoped<ApiHelper>();
        services.AddScoped<AccountEndPoint>();

        return services;
    }

}