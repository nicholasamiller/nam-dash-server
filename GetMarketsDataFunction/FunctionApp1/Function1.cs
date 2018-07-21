using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json.Linq;

namespace GetFinancials
{
    public static class GetMarketData
    {
        private static string _alphaVantageApiKey = "X1MPND40I6XHJQHN";

        private static string _url =
            "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=VGS&interval=1min&apikey=X1MPND40I6XHJQHN";

        private static HttpClient _httpClient = new HttpClient();

        [FunctionName("GetFinacials")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            try
            {

                var vgsResponse = await _httpClient.GetStringAsync(_url);
                JObject parsed = JObject.Parse(vgsResponse);
                var lastRefreshed = parsed["Meta Data"]["3. Last Refreshed"].Value<string>();

                var lastPrice = parsed["Time Series (1min)"][lastRefreshed]["4. close"].Value<string>();

                var asDecimal = Convert.ToDecimal(lastPrice);


                JArray responseBody = new JArray();
                responseBody.Add(new JObject(new JProperty("VGS MSCI ETF"
                    , new JObject(
                        new JProperty("Last", "$" + asDecimal)
                    ))));

                var response = req.CreateResponse();
                response.Content = new StringContent(responseBody.ToString(), Encoding.UTF8, "application/json");
                response.StatusCode = HttpStatusCode.OK;

                return response;
            }
            catch
            {

                var response = req.CreateResponse();
                response.StatusCode = HttpStatusCode.ServiceUnavailable;
                return response;
            }
        }
    }
}
