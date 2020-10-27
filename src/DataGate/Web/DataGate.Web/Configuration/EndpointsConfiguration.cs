namespace DataGate.Web.Configuration
{
    using Microsoft.AspNetCore.Builder;

    public static class EndpointsConfiguration
    {
        public static IApplicationBuilder ConfigureEndpoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute(
                         name: "userpanel",
                         pattern: "userpanel",
                         new { controller = "User", action = "Index" });

                    endpoints.MapControllerRoute(
                         name: "privacy",
                         pattern: "privacy",
                         new { controller = "Legal", action = "Privacy" });
                    endpoints.MapControllerRoute(
                          name: "cookie",
                          pattern: "cookie",
                          new { controller = "Legal", action = "Cookie" });
                    endpoints.MapControllerRoute(
                          name: "conditions",
                          pattern: "conditions",
                          new { controller = "Legal", action = "Conditions" });

                    // Media files
                    endpoints.MapControllerRoute(
                         name: "files",
                         pattern: "media/{name:minlength(5)}",
                         new { controller = "Media", action = "Read" });
                    endpoints.MapControllerRoute(
                         name: "fees",
                         pattern: "fees/{fileId}",
                         new { controller = "Fees", action = "Index" });
                    endpoints.MapControllerRoute(
                          name: "search-results",
                          pattern: "search-results",
                          new { controller = "Search", action = "Result" });
                    endpoints.MapControllerRoute(
                        name: "allagreements",
                        pattern: "allagreements",
                        new { controller = "Agreements", action = "Overview" });
                    endpoints.MapControllerRoute(
                       name: "agreements",
                       pattern: "agreements/{type:required}",
                       new { controller = "Agreements", action = "All" });

                    // Reports
                    endpoints.MapControllerRoute(
                       name: "allreports",
                       pattern: "reports",
                       new { controller = "Reports", action = "Overview" });
                    endpoints.MapControllerRoute(
                       name: "reports",
                       pattern: "reports/{type:required}",
                       new { controller = "Reports", action = "All" });
                    endpoints.MapControllerRoute(
                      name: "fundreports",
                      pattern: "reports/fund",
                      new { controller = "Reports", action = "FundReports" });
                    endpoints.MapControllerRoute(
                     name: "timeseriesreports",
                     pattern: "reports/timeseries",
                     new { controller = "Reports", action = "TSReports" });

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
                          name: "newSubFund",
                          areaName: "Admin",
                          pattern: "sf/new",
                          new { area = "Admin", controller = "SubFundStorage", action = "Create" });
                    endpoints.MapAreaControllerRoute(
                          name: "editSubFund",
                          areaName: "Admin",
                          pattern: "sf/edit/{id:int:min(1)}/{date:required}",
                          new { area = "Admin", controller = "SubFundStorage", action = "Edit" });
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
                          name: "newShareClass",
                          areaName: "Admin",
                          pattern: "sc/new",
                          new { area = "Admin", controller = "ShareClassStorage", action = "Create" });
                    endpoints.MapAreaControllerRoute(
                          name: "editShareClass",
                          areaName: "Admin",
                          pattern: "sc/edit/{id:int:min(1)}/{date:required}",
                          new { area = "Admin", controller = "ShareClassStorage", action = "Edit" });
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

            return app;
        }
    }
}
