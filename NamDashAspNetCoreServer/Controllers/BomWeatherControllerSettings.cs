using System;
using Microsoft.AspNetCore.Mvc;

namespace NamDashAspNetCoreServer.Controllers
{
    public class BomWeatherControllerSettings
    {
        public Uri Endpoint { get; }

        public BomWeatherControllerSettings(string url)
        {
            Endpoint = new Uri(url);
        }

           }
}