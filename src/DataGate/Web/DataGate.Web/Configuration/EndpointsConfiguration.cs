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
                    // ________________________________________________________
                    //
                    // Endpoint names not globalized for readability

                    endpoints.MapControllerRoute(
                         name: "userpanel",
                         pattern: "userpanel",
                         new { controller = "User", action = "Index" });


                    endpoints.MapControllerRoute(
                         name: "privacy",
                         pattern: "privacy",
                         new { controller = EndpointsConstants.LegalController, action = "Privacy" });

                    endpoints.MapControllerRoute(
                          name: "cookie",
                          pattern: "cookie",
                          new { controller = EndpointsConstants.LegalController, action = "Cookie" });

                    endpoints.MapControllerRoute(
                          name: "conditions",
                          pattern: "conditions",
                          new { controller = EndpointsConstants.LegalController, action = "Conditions" });

                    // ________________________________________________________
                    //
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
                        new { controller = EndpointsConstants.AgreementsController, action = "Overview" });

                    endpoints.MapControllerRoute(
                       name: "agreements",
                       pattern: $"agreements/{EndpointsConstants.RoutePropertyType}",
                       new { controller = EndpointsConstants.AgreementsController, action = EndpointsConstants.ActionAll });

                    // ________________________________________________________
                    //
                    // Reports
                    endpoints.MapControllerRoute(
                      name: "reportoverview",
                      pattern: "reportoverview",
                      new { controller = EndpointsConstants.ReportsController, action = "MainOverview" });

                    endpoints.MapControllerRoute(
                       name: "allreports",
                       pattern: $"reports/{EndpointsConstants.RoutePropertyType}",
                       new { controller = EndpointsConstants.ReportsController, action = "SubOverview" });

                    endpoints.MapControllerRoute(
                       name: "aumreports",
                       pattern: $"reports/{EndpointsConstants.RoutePropertyType}/aum",
                       new { controller = EndpointsConstants.ReportsController, action = "AuMReports" });

                    endpoints.MapControllerRoute(
                     name: "timeseriesreports",
                     pattern: $"reports/{EndpointsConstants.RoutePropertyType}/timeseries/{EndpointsConstants.RoutePropertyIdNull}",
                     new { controller = EndpointsConstants.ReportsController, action = "TSReports" });

                    // ________________________________________________________
                    //
                    // Funds
                    endpoints.MapAreaControllerRoute(
                          name: "newFund",
                          areaName: EndpointsConstants.AdminAreaName,
                          pattern: "f/new",
                          new
                          {
                              area = EndpointsConstants.AdminAreaName,
                              controller = EndpointsConstants.FundArea + EndpointsConstants.DisplayStorage,
                              action = EndpointsConstants.ActionCreate
                          });

                    endpoints.MapAreaControllerRoute(
                          name: "editFund",
                          areaName: EndpointsConstants.AdminAreaName,
                          pattern: $"f/edit/{EndpointsConstants.RoutePropertyId}/{EndpointsConstants.RoutePropertyDate}",
                          new
                          {
                              area = EndpointsConstants.AdminAreaName,
                              controller = EndpointsConstants.FundArea + EndpointsConstants.DisplayStorage,
                              action = EndpointsConstants.ActionEdit
                          });

                    endpoints.MapAreaControllerRoute(
                           name: "allFunds",
                           areaName: EndpointsConstants.FundArea,
                           pattern: "funds",
                           new
                           {
                               area = EndpointsConstants.FundArea,
                               controller = EndpointsConstants.FundsController,
                               action = EndpointsConstants.ActionAll
                           });

                    endpoints.MapAreaControllerRoute(
                           name: "detailsFund",
                           areaName: EndpointsConstants.FundArea,
                           pattern: $"f/{EndpointsConstants.RoutePropertyId}/{EndpointsConstants.RoutePropertyDate}",
                           new
                           {
                               area = EndpointsConstants.FundArea,
                               controller = EndpointsConstants.FundArea + EndpointsConstants.ActionDetails,
                               action = EndpointsConstants.ActionDetails
                           });

                    endpoints.MapAreaControllerRoute(
                           name: "fundSubFunds",
                           areaName: EndpointsConstants.FundArea,
                           pattern: $"f/{EndpointsConstants.RoutePropertyId}/sf",
                           new { area = EndpointsConstants.FundArea, controller = "FundSubFunds", action = "SubFunds" });

                    // ________________________________________________________
                    //
                    // Sub Funds
                    endpoints.MapAreaControllerRoute(
                          name: "newSubFund",
                          areaName: EndpointsConstants.AdminAreaName,
                          pattern: "sf/new",
                          new
                          {
                              area = EndpointsConstants.AdminAreaName,
                              controller = EndpointsConstants.DisplaySub + EndpointsConstants.FundArea + EndpointsConstants.DisplayStorage,
                              action = EndpointsConstants.ActionCreate
                          });

                    endpoints.MapAreaControllerRoute(
                          name: "editSubFund",
                          areaName: EndpointsConstants.AdminAreaName,
                          pattern: $"sf/edit/{EndpointsConstants.RoutePropertyId}/{EndpointsConstants.RoutePropertyDate}",
                          new
                          {
                              area = EndpointsConstants.AdminAreaName,
                              controller = EndpointsConstants.DisplaySub + EndpointsConstants.FundArea + EndpointsConstants.DisplayStorage,
                              action = EndpointsConstants.ActionEdit
                          });

                    endpoints.MapAreaControllerRoute(
                           name: "allSubFunds",
                           areaName: EndpointsConstants.DisplaySub + EndpointsConstants.FundArea,
                           pattern: "subfunds",
                           new
                           {
                               area = EndpointsConstants.DisplaySub + EndpointsConstants.FundArea,
                               controller = EndpointsConstants.DisplaySub + EndpointsConstants.FundsController,
                               action = EndpointsConstants.ActionAll
                           });

                    endpoints.MapAreaControllerRoute(
                           name: "detailsSubFund",
                           areaName: EndpointsConstants.DisplaySub + EndpointsConstants.FundArea,
                           pattern: $"sf/{EndpointsConstants.RoutePropertyId}/{EndpointsConstants.RoutePropertyDate}",
                           new
                           {
                               area = EndpointsConstants.DisplaySub + EndpointsConstants.FundArea,
                               controller = "SubFundDetails",
                               action = EndpointsConstants.ActionDetails
                           });

                    endpoints.MapAreaControllerRoute(
                           name: "subFundShareClasses",
                           areaName: EndpointsConstants.DisplaySub + EndpointsConstants.FundArea,
                           pattern: $"sf/{EndpointsConstants.RoutePropertyId}/sc",
                           new
                           {
                               area = EndpointsConstants.DisplaySub + EndpointsConstants.FundArea,
                               controller = "SubFundShareClasses",
                               action = "ShareClasses"
                           });

                    // ________________________________________________________
                    //
                    // Share Classes
                    endpoints.MapAreaControllerRoute(
                          name: "newShareClass",
                          areaName: EndpointsConstants.AdminAreaName,
                          pattern: "sc/new",
                          new
                          {
                              area = EndpointsConstants.AdminAreaName,
                              controller = EndpointsConstants.ShareClassArea + EndpointsConstants.DisplayStorage,
                              action = EndpointsConstants.ActionCreate
                          });

                    endpoints.MapAreaControllerRoute(
                          name: "editShareClass",
                          areaName: EndpointsConstants.AdminAreaName,
                          pattern: $"sc/edit/{EndpointsConstants.RoutePropertyId}/{EndpointsConstants.RoutePropertyDate}",
                          new
                          {
                              area = EndpointsConstants.AdminAreaName,
                              controller = EndpointsConstants.ShareClassArea + EndpointsConstants.DisplayStorage,
                              action = EndpointsConstants.ActionEdit
                          });

                    endpoints.MapAreaControllerRoute(
                           name: "allShareClasses",
                           areaName: EndpointsConstants.ShareClassArea,
                           pattern: "shareclasses",
                           new
                           {
                               area = EndpointsConstants.ShareClassArea,
                               controller = EndpointsConstants.ShareClassesController,
                               action = EndpointsConstants.ActionAll
                           });

                    endpoints.MapAreaControllerRoute(
                           name: "detailsShareClass",
                           areaName: EndpointsConstants.ShareClassArea,
                           pattern: $"sc/{EndpointsConstants.RoutePropertyId}/{EndpointsConstants.RoutePropertyDate}",
                           new
                           {
                               area = EndpointsConstants.ShareClassArea,
                               controller = EndpointsConstants.ShareClassArea + EndpointsConstants.ActionDetails,
                               action = EndpointsConstants.ActionDetails
                           });

                    // ________________________________________________________
                    //
                    // Default routing
                    endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
                });

            return app;
        }
    }
}
