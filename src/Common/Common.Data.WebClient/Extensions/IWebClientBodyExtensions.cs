using Common.Data.WebClient.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Common.Data.WebClient.Extensions
{
    public static class IWebClientBodyExtensions
    {
        public static IWebClient WithStringContent(this IWebClient webClient, string bodyContent)
        {
            var data = new StringContent(bodyContent, Encoding.UTF8, "application/json");

            webClient.Configuration.HttpContent = data;

            return webClient;
        }

        public static IWebClient WithStringContent(this IWebClient webClient, object bodyContentObject)
        {
            var json = JsonConvert.SerializeObject(bodyContentObject);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            webClient.Configuration.HttpContent = data;

            return webClient;
        }
    }
}
