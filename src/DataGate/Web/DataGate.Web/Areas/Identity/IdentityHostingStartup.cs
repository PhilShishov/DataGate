﻿using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(DataGate.Web.Areas.Identity.IdentityHostingStartup))]

namespace DataGate.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
