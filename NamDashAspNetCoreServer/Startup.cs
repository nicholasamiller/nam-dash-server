using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using NamDashAspNetCoreServer.Data;
using NamDashAspNetCoreServer.Exceptions;
using NamDashAspNetCoreServer.Interfaces;

namespace NamDashAspNetCoreServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }    

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var quotesUrl = Configuration.GetValue<string>("QuotesStorageUrl");
            if (quotesUrl == null)
            {
                throw new ConfigurationException("Need URL for quotes.");
            }

            services.AddSingleton<HttpClient,HttpClient>();
            services.AddSingleton<AzureStorageQuotesRepoSettings,AzureStorageQuotesRepoSettings>(provider =>
                new AzureStorageQuotesRepoSettings(quotesUrl));
            services.AddSingleton<IQuotesRepository, AzureDataStorageQuotesRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
