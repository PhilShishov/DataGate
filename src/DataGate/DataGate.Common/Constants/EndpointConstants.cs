// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Common
{
    public class EndpointsConstants
    {
        // Controllers, areas
        public const string AdminAreaName = "Admin";
        public const string IdentityAreaName = "Identity";
        public const string ControllerRouteDataValue = "controller";
        public const string AreaRouteDataValue = "area";

        public const string DisplaySub = "Sub";
        public const string DisplayStorage = "Storage";
        public const string FundArea = "Fund";
        public const string FundsController = "Funds";
        public const string ShareClassArea = "ShareClass";
        public const string ShareClassesController = "ShareClasses";
        public const string SubFundShareClassesController = DisplaySub + FundArea + ShareClassesController;
        public const string LegalController = "Legal";
        public const string AgreementsController = "Agreements";
        public const string ReportsController = "Reports";

        public const string SubFundNameDisplay = "Sub Fund";
        public const string ShareClassNameDisplay = "Share Class";

        // Abbreviations
        public const string FundAbbreviation = "f";
        public const string SubFundAbbreviation = "sf";
        public const string ShareClassAbbreviation = "sc";

        // Urls, actions
        public const string Slash = "/";
        public const string ActionAll = "All";
        public const string ActionDetails = "Details";
        public const string ActionCreate = "Create";
        public const string ActionEdit = "Edit";

        // Routes and route properties
        public const string RouteUserPanel = "userpanel";
        public const string RouteFees = "fees";
        public const string RouteAll = "all";
        public const string RouteDetails = "details";
        public const string RouteCreate = "new";
        public const string RouteEdit = "edit";
        public const string RouteAgreements = "agreements";
        public const string RouteReports = "reportoverview";
        public const string RouteSearch = "search-results";
        public const string RoutePropertyType = "{type:required}";
        public const string RoutePropertyDate = "{date:required}";
        public const string RoutePropertyId = "{id:int:min(1)}";
        public const string RoutePropertyIdNull = "{id?}";

        public const string FundSubFundsRouteName = "fundSubFunds";
        public const string SubFundShareClassesRouteName = "subFundShareClasses";
    }
}
