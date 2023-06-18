using InvBank.Web.Helper.EndPoints;

namespace InvBank.Web.Helper;

public static class DependencyInjection
{

    public static IServiceCollection AddHelper(this IServiceCollection services)
    {

        services.AddScoped<ApiHelper>();

        // Endpoints
        services.AddScoped<AccountEndPoint>();
        services.AddScoped<AuthenticationEndPoint>();
        services.AddScoped<BankEndPoint>();
        services.AddScoped<DepositEndPoint>();
        services.AddScoped<FundEndPoint>();
        services.AddScoped<PropertyAccountEndPoint>();
        services.AddScoped<ReportEndPoint>();

        return services;
    }

}