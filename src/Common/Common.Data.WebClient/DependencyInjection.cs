using Common.Data.WebClient.Interfaces;
using Common.Data.WebClient.Options;
using Common.Data.WebClient.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Data.WebClient
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebClient(this IServiceCollection services, IConfiguration configuration)
        { 
            // register options
            services.Configure<WebResourcesOptions>(configuration.GetSection("WebResources"));

            // add context accessor
            services.AddHttpContextAccessor();

            services.AddHttpClient();
            services.AddHttpClient("no-ssl-validation")
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler
                    {
                        ClientCertificateOptions = ClientCertificateOption.Manual,
                        ServerCertificateCustomValidationCallback =
                            (httpRequestMessage, cert, certChain, policyErrors) => true
                    };
                });

            // register web client services
            services.AddTransient<IWebClient, WebClientService>();

            return services;
        }
    }
}
