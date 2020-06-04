namespace DataGate.Web
{
    using System.Reflection;

    using DataGate.Common;
    using DataGate.Data;
    using DataGate.Data.Seeding;
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
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString(GlobalConstants.DataGateUsersConnection)));

            services.AddDbContext<Pharus_vFinaleDbContext>(
               options => options.UseSqlServer(this.configuration.GetConnectionString(GlobalConstants.DataGatevFinaleConnection)));

            services.ConfigureIdentity()
                .ConfigureSession()
                .ConfigureCache(this.configuration)
                .ConfigureLocalization()
                .ConfigureMvc()
                .ConfigureCookies()
                .ConfigureSettings(this.configuration)
                .ConfigureForms()
                .ConfigureAntiForgery()
                .ConfigureViews()
                .ConfigureAuthorization()
                .AddRepositories()
                .AddBusinessLogicServices(this.configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            LocalizationConfiguration.SetDefaultCulture();

            AutoMapperConfig.RegisterMappings(
                typeof(ErrorViewModel).GetTypeInfo().Assembly,
                typeof(EditFundInputModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

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

            app.UseEndpoints(
                endpoints =>
                    {
                        // Media files
                        endpoints.MapControllerRoute(
                             name: "files",
                             pattern: "media/{name:minlength(5)}",
                             new { controller = "Media", action = "Read" });
                        endpoints.MapControllerRoute(
                              name: "search-results",
                              pattern: "search-results",
                              new { controller = "Search", action = "Result" });
                        endpoints.MapControllerRoute(
                            name: "agreements",
                            pattern: "agreements",
                            new { controller = "Agreements", action = "All" });

                        // Funds
                        endpoints.MapAreaControllerRoute(
                              name: "newFund",
                              areaName: "Admin",
                              pattern: "f/new",
                              new { area = "Admin", controller = "FundStorage", action = "Create" });
                        endpoints.MapAreaControllerRoute(
                              name: "editFund",
                              areaName: "Admin",
                              pattern: "f/edit/{id:int:min(1)}/{date:required}",
                              new { area = "Admin", controller = "FundStorage", action = "Edit" });
                        endpoints.MapAreaControllerRoute(
                               name: "allFunds",
                               areaName: "Fund",
                               pattern: "funds",
                               new { area = "Fund", controller = "Funds", action = "All" });
                        endpoints.MapAreaControllerRoute(
                               name: "fundDetails",
                               areaName: "Fund",
                               pattern: "f/{id:int:min(1)}/{date:required}",
                               new { area = "Fund", controller = "FundDetails", action = "Details" });
                        endpoints.MapAreaControllerRoute(
                               name: "fundSubFunds",
                               areaName: "Fund",
                               pattern: "f/{id:int:min(1)}/sf",
                               new { area = "Fund", controller = "FundSubFunds", action = "SubFunds" });

                        // Sub Funds
                        endpoints.MapAreaControllerRoute(
                               name: "allSubFunds",
                               areaName: "SubFund",
                               pattern: "subfunds",
                               new { area = "SubFund", controller = "SubFunds", action = "All" });
                        endpoints.MapAreaControllerRoute(
                               name: "subFundDetails",
                               areaName: "SubFund",
                               pattern: "sf/{id:int:min(1)}/{date:required}",
                               new { area = "SubFund", controller = "SubFundDetails", action = "Details" });
                        endpoints.MapAreaControllerRoute(
                               name: "subFundShareClasses",
                               areaName: "SubFund",
                               pattern: "sf/{id:int:min(1)}/sc",
                               new { area = "SubFund", controller = "SubFundShareClasses", action = "ShareClasses" });

                        // Share Classes
                        endpoints.MapAreaControllerRoute(
                               name: "allShareClasses",
                               areaName: "ShareClass",
                               pattern: "shareclasses",
                               new { area = "ShareClass", controller = "ShareClasses", action = "All" });
                        endpoints.MapAreaControllerRoute(
                               name: "shareClassDetails",
                               areaName: "ShareClass",
                               pattern: "sc/{id:int:min(1)}/{date:required}",
                               new { area = "ShareClass", controller = "ShareClassDetails", action = "Details" });

                        // Default routing
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
