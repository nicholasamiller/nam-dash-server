using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NamDashAspNetCoreServer.Interfaces;

namespace NamDashAspNetCoreServer.Controllers
{
    [Produces("application/json")]
    [Route("api/Quotes")]
    public class QuotesController : Controller
    {
        private readonly IQuotesRepository _quotesRepository;

        public QuotesController(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        [HttpGet("getRandom")]
        public async Task<string> GetRandom()
        {
            var quote = await _quotesRepository.GetRandomQuote();
            return quote;
        }

        [HttpGet("getQuoteOfDay")]
        public async Task<string> GetQuoteOfDay()
        {
            var q = await _quotesRepository.GetQuoteOfTheDay();
            return q;
        }
    }
}