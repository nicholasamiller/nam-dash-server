using System;

namespace NamDashAspNetCoreServer.Data
{
    public class AzureStorageQuotesRepoSettings
    {
        public Uri UrlForStorage { get; }

        public AzureStorageQuotesRepoSettings(string urlForStorage)
        {
            UrlForStorage = new Uri(urlForStorage);
        }
    }
}