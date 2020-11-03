namespace DataGate.Common
{
    public class EndpointsConstants
    {
        // Controllers, areas
        public const string AdminAreaName = "Admin";

        public const string ControllerRouteDataValue = "controller";
        public const string FundArea = "Fund";
        public const string FundsController = "Funds";

        public const string ShareClassArea = "ShareClass";
        public const string ShareClassesController = "ShareClasses";

        public const string SubFundShareClassesController = DisplaySub + FundArea + ShareClassesController;

        public const string SubFundNameDisplay = "Sub Fund";
        public const string ShareClassNameDisplay = "Share Class";

        // Abbreviations
        public const string FundAbbreviation = "F";
        public const string SubFundAbbreviation = "SF";
        public const string ShareClassAbbreviation = "SC";

        // Urls, actions
        public const string Slash = "/";
        public const string UserPanelUrl = "userpanel";
        public const string ActionAll = "All";
        public const string ActionDetails = "Details";

        // Routes names
        public const string RouteFees = "fees";
        public const string DisplaySub = "Sub";
        public const string DisplayAll = "all";
        public const string DisplayDetails = "details";

        public const string FundDetailsRouteName = "detailsFund";
        public const string FundSubFundsRouteName = "fundSubFunds";
        public const string FundCreateRouteName = "newFund";
        public const string FundEditRouteName = "editFund";

        public const string AllSubFundsRouteName = "allSubFunds";
        public const string SubFundDetailsRouteName = "subFundDetails";
        public const string SubFundShareClassesRouteName = "subFundShareClasses";
        public const string SubFundCreateRouteName = "newSubFund";
        public const string SubFundEditRouteName = "editSubFund";

        public const string AllShareClassesRouteName = "allShareClasses";
        public const string ShareClassDetailsRouteName = "shareClassDetails";
        public const string ShareClassCreateRouteName = "newShareClass";
        public const string ShareClassEditRouteName = "editShareClass";
    }
}
