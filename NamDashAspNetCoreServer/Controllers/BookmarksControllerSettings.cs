using System;

namespace NamDashAspNetCoreServer.Controllers
{
    public class BookmarksControllerSettings
    {
        public Uri Uri { get; }

        public BookmarksControllerSettings(string url)
        {
            Uri = new Uri(url);
        }
    }
}