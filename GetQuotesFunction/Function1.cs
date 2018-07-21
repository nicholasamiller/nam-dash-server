using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace GetQuotesFunction
{
    public static class Function1
    {

        private static HttpClient _httpClient = new HttpClient();
        private static string urlOfQuotesFile = "https://personaldashboardstoarge.blob.core.windows.net/static-content/data/quotes.txt";

        [FunctionName("GetQuote")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get",  Route = "getQuote")]HttpRequestMessage req, TraceWriter log)
        {
            var quotesFile = await _httpClient.GetStringAsync(urlOfQuotesFile);
            
            var quotes = quotesFile.Split(new string[] { Environment.NewLine},StringSplitOptions.RemoveEmptyEntries);

            var random = new Random();
            var randomQuoteIndex = random.Next(0, quotes.Length);

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            StringContent content = new StringContent(quotes[randomQuoteIndex]);
            response.Content = content;

            return response;

        }   
    }
}
