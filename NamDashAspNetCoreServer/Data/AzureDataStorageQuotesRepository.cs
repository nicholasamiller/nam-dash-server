using NamDashAspNetCoreServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;

namespace NamDashAspNetCoreServer.Data
{
    public class AzureDataStorageQuotesRepository : IQuotesRepository
    {
        private readonly IList<string> _quotes;

        public AzureDataStorageQuotesRepository(AzureStorageQuotesRepoSettings queAzureStorageQuotesRepoSettings, HttpClient httpClient)
        {
            var quotesFile = httpClient.GetStringAsync(queAzureStorageQuotesRepoSettings.UrlForStorage).Result;
            _quotes = quotesFile.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
        }

        public Task<string> GetRandomQuote()
        {
            var random = new Random();
            var randomQuoteIndex = random.Next(0, _quotes.Count);
            return Task.FromResult(_quotes[randomQuoteIndex]);
        }
    }
}
