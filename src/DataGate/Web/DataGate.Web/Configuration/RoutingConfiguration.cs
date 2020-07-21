namespace DataGate.Web.Configuration
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    public static class RoutingConfiguration
    {
        public static IServiceCollection ConfigureRouting(this IServiceCollection services)
        {
            //services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllersWithViews(
               options =>
               {
                   options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
               });
            services.AddRazorPages()
                  .AddRazorPagesOptions(options =>
                  {
                      options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "/account/login");
                      options.Conventions.AddAreaPageRoute("Identity", "/Account/Logout", "/account/logout");
                      options.Conventions.AddAreaPageRoute("Identity", "/Account/ForgotPassword", "/account/forgot-password");
                      options.Conventions.AddAreaPageRoute("Identity", "/Account/ForgotPasswordConfirmation", "/account/confirmation");
                      options.Conventions.AddAreaPageRoute("Identity", "/Account/ResetPassword", "/account/reset-password");
                      options.Conventions.AddAreaPageRoute("Identity", "/Account/ConfirmEmail", "/account/confirm-email");
                      options.Conventions.AddAreaPageRoute("Identity", "/Account/AccessDenied", "/account/access-denied");
                      options.Conventions.AddAreaPageRoute("Identity", "/Account/Manage/Email", "/account/email");
                      options.Conventions.AddAreaPageRoute("Identity", "/Account/Manage/ChangePassword", "/account/change-password");
                      options.Conventions.AddAreaPageRoute("Identity", "/Account/Manage/TwoFactorAuthentication", "/account/two-factor-auth");
                      options.Conventions.AddAreaPageRoute("Identity", "/Account/Manage/EnableAuthenticator", "/account/enable-auth");
                      options.Conventions.AddAreaPageRoute("Identity", "/Account/Manage/ResetAuthenticator", "/account/reset-auth");
                      options.Conventions.AddAreaPageRoute("Identity", "/Account/Manage/PersonalData", "/account/personal-data");
                      options.Conventions.AddAreaPageRoute("Identity", "/Account/Manage/DeletePersonalData", "/account/delete-personal-data");
                  });

            return services;
        }
    }
}
