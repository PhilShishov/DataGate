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
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute(
                             name: "files",
                             pattern: "media/{name:minlength(5)}",
                             new { controller = "Media", action = "Read" });
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
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
