using Common.Data.Exceptions;
using Common.Data.WebClient.Interfaces;
using Common.Data.WebClient.Models;
using Common.Data.WebClient.Options;

namespace Common.Data.WebClient.Extensions
{
    public static class IWebClientConfigureExtensions
    {
        public static IWebClient Configure(this IWebClient webClient, Action<IWebClientConfiguration> baseConfiguration)
        {
            // get configuration
            var cnfg = new WebClientConfiguration();
            baseConfiguration.Invoke(cnfg);

            // configure web resource
            if (!string.IsNullOrEmpty(cnfg.WebResourcePath))
                webClient.WithWebResource(cnfg.WebResourcePath);

            // configure request uri
            if (!string.IsNullOrEmpty(cnfg.RequestUri))
                webClient.WithUri(cnfg.RequestUri);

            // set default authentication type
            //webClient.Configuration.AuthenticationType = cnfg.AuthenticationType;

            //switch (webClient.Configuration.AuthenticationType)
            //{
            //    case Enums.AuthenticationType.Basic:
            //        webClient.WithBasicAuthentication();
            //        break;

            //    case Enums.AuthenticationType.Bearer:
            //        webClient.WithBearerAuthentication();
            //        break;

            //    case Enums.AuthenticationType.Current:
            //        break;
            //}

            return webClient;
        }

        public static IWebClient WithWebResource(this IWebClient webClient, string webResourcePath)
        {
            var engine = webClient as IWebClientEngine;
            engine.SetWebResource(webResourcePath);

            return webClient;
        }

        public static IWebClient WithWebResource(this IWebClient webClient, WebResource webResource)
        {
            var segment = webResource.Segments.FirstOrDefault();

            webClient.Configuration.WebResource = webResource ??
                throw new NotFoundException($"Resource not found in resources collection");

            webClient.Configuration.Segment = segment ??
                throw new NotFoundException($"No segment in resource {webResource.Name} segments collection");

            webClient.Configuration.RequestUri = webClient.Configuration.WebResource.Host + webClient.Configuration.Segment.Url;

            return webClient;
        }

        public static IWebClient WithUri(this IWebClient webClient, string uri)
        {
            webClient.Configuration.WebResource = null;
            webClient.Configuration.Segment = null;
            webClient.Configuration.WebResourcePath = string.Empty;

            webClient.Configuration.RequestUri = uri;

            return webClient;
        }
    }
}
