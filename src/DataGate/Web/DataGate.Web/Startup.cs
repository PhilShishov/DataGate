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
                .ConfigureDataProtection(this.configuration)
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
            //using (var serviceScope = app.ApplicationServices.CreateScope())
            //{
            //    var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            //    //if (env.IsDevelopment())
            //    //{
            //    //    dbContext.Database.Migrate();
            //    //}

            //    new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            //}

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

            app.ConfigureEndpoints();
        }
    }
}
