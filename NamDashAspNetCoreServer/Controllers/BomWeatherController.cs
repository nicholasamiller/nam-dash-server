using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace NamDashAspNetCoreServer.Controllers
{

    [Produces("application/json")]
    [Route("api/Weather")]
    public class BomWeatherController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _url =
            "https://bom-observations.azurewebsites.net/api/GetBomWeatherData?location=Canberra&code=oZM6S0mx7d6N9IscagDdfGokHMF5/CmQGEuXW75yGpQik6hh4iKSmg==";
        public BomWeatherController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        [HttpGet("getBomData")]
        public async Task<ContentResult> GetBomData()
        {
            var data = await _httpClient.GetStringAsync(_url);
            return new ContentResult() {Content = data, ContentType = "application/json; charset=utf-8", StatusCode = 200};
        }

    }
}
