namespace DataGate.Web.Configuration
{
    using DataGate.Common;
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
                      name: "reportoverview",
                      pattern: "reportoverview",
                      new { controller = "Reports", action = "MainOverview" });
                    endpoints.MapControllerRoute(
                       name: "allreports",
                       pattern: "reports/{type:required}",
                       new { controller = "Reports", action = "SubOverview" });
                    endpoints.MapControllerRoute(
                       name: "aumreports",
                       pattern: "reports/{type:required}/aum",
                       new { controller = "Reports", action = "AuMReports" });
                    endpoints.MapControllerRoute(
                     name: "timeseriesreports",
                     pattern: "reports/{type:required}/timeseries/{id?}",
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
                           name: EndpointsConstants.RouteAll + EndpointsConstants.FundsController,
                           areaName: EndpointsConstants.FundArea,
                           pattern: EndpointsConstants.FundsController.ToLower(),
                           new { area = EndpointsConstants.FundArea, 
                                 controller = EndpointsConstants.FundsController, 
                                 action = EndpointsConstants.ActionAll });
                    endpoints.MapAreaControllerRoute(
                           name: EndpointsConstants.RouteDetails + EndpointsConstants.FundArea,
                           areaName: EndpointsConstants.FundArea,
                           pattern: "f/{id:int:min(1)}/{date:required}",
                           new { area = EndpointsConstants.FundArea, 
                               controller = EndpointsConstants.FundArea + EndpointsConstants.ActionDetails, 
                               action = EndpointsConstants.ActionDetails });
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
                           name: "detailsSubFund",
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
                           name: "detailsShareClass",
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
