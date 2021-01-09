// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web
{
    using System.Reflection;

    using DataGate.Common;
    using DataGate.Data;
    using DataGate.Services.Mapping;
    using DataGate.Web.Configuration;
    using DataGate.Web.InputModels.Funds;
    using DataGate.Web.ViewModels;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // ---------------------------------------------------------
            //
            // Database Connection settings
            services.AddDbContext<UsersDbContext>(options => 
                     options.UseSqlServer(this.configuration.GetConnectionString(GlobalConstants.DataGateUsersConnection)));

            services.AddDbContext<ApplicationDbContext>(options => 
                     options.UseSqlServer(this.configuration.GetConnectionString(GlobalConstants.DataGateAppConnection)));

            services.ConfigureIdentity()
                .ConfigureSession()
                .ConfigureDataProtection(this.configuration)
                .ConfigureCache()
                .ConfigureLocalization()
                .ConfigureCookies()
                .ConfigureSettings(this.configuration)
                .ConfigureForms()
                .ConfigureAntiForgery()
                .ConfigureRouting()
                .ConfigureAuthorization()
                .AddRepositories()
                .AddEmailSendingService(this.configuration)
                .AddBusinessLogicServices();
            services.AddApplicationInsightsTelemetry();
            services.AddSignalR();
            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(
                typeof(ErrorViewModel).GetTypeInfo().Assembly,
                typeof(EditFundInputModel).GetTypeInfo().Assembly);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home/Error";
                    await next();
                }
            });

            app.UseResponseCompression();
            app.UseResponseCaching();
            app.UseHttpsRedirection();
            app.UserLocalization();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.ConfigureEndpoints();
        }
    }
}
