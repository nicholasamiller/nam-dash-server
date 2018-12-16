using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NamDashAspNetCoreServer.Controllers
{
    [Produces("application/json")]
    [Route("api/Bookmarks")]
    public class BookmarksController : Controller
    {
        public BookmarksController(HttpClient httpClient)
        {

        }

    }
}