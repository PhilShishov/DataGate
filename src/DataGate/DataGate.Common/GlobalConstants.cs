namespace DataGate.Common
{
    public static class GlobalConstants
    {
        // Application Constants
        public const string SystemName = "DataGate";
        public const string SystemBaseUrl = "https://pharusdatagate.com";
        public const string DataGateFullFooterDisplay = "- Pharus Management Lux SA 16, Avenue de la Gare L-1610 Luxembourg";
        public const string DataGateFooterDisplay = "- Pharus Management Lux SA";
        public const string FileSizeLimitConfiguration = "FileSizeLimit";
        public const string CurrentCultureInfo = "en-US";
        public const string ItalianCultureInfo = "it-IT";
        public const int CultureCookieExpirationTimeInMonths = 5;

        // Controllers, areas
        public const string ControllerRouteDataValue = "controller";
        public const string FundAreaName = "Fund";
        public const string FundsControllerName = "Funds";
        public const string FundDetailsControllerName = "FundDetails";
        public const string FundSubFundsControllerName = "FundSubFunds";

        public const string SubFundsControllerName = "SubFunds";
        public const string SubFundAreaName = "SubFund";
        public const string SubFundDetailsControllerName = "SubFundDetails";
        public const string SubFundShareClassesControllerName = "SubFundShareClasses";

        public const string ShareClassesControllerName = "ShareClasses";
        public const string ShareClassDetailsControllerName = "ShareClassDetails";
        public const string ShareClassAreaName = "ShareClass";
        public const string ShareClassesSubEntitiesControllerName = "ShareClassesSubEntities";

        // Urls, actions
        public const string FundAllUrl = "/funds";
        public const string SubFundAllUrl = "/subfunds";
        public const string ShareClassAllUrl = "/shareclasses";
        public const string UserPanelUrl = "/userpanel";
        public const string DetailsActionName = "Details";
        public const string AllActionName = "All";
        public const string EditActionName = "Edit";
        public const string CreateActionName = "Create";

        // Routes names
        public const string FeesRouteName = "fees";
        public const string AllFundsRouteName = "allFunds";
        public const string FundDetailsRouteName = "fundDetails";
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

        // Tempdata Keys
        public const string SweetAlertKey = "sweetalert";
        public const string SweetAlertScript = "<script type='text/javascript'>swal('{0}', '{1}','{2}');</script>";
        public const string AlertifyKey = "alertify";
        public const string AlertifyScript = "<script type='text/javascript'>alertify.set('notifier', 'position', 'top-left'); alertify.notify('{0}', '{1}', 5);</script>";

        // Connection Strings
        public const string DataGateUsersConnection = "DataGateUsersConnection";
        public const string DataGatevFinaleConnection = "DataGate_vFinaleConnection";

        // User Roles
        public const int MaxAdminCount = 3;
        public const string AdministratorRoleName = "Admin";
        public const string RiskRoleName = "Risk";
        public const string LegalRoleName = "Legal";
        public const string InvestmentRoleName = "Investment";
        public const string ComplianceRoleName = "Compliance";
        public const string GuestRoleName = "Guest";

        // Email
        public const string ConfirmEmailSubject = "PHARUS DATAGATE: Confirm your email";
        public const string EmailConfirmationMessage = "This is an automatic email sent by Pharus DataGate to authorize your account with chosen username and password.<br>" +
                                                       "Please confirm your account by <a href='{0}'>clicking here</a>.";

        public const string ResetPasswordEmailSubject = "Reset your password";
        public const string PasswordResetMessage = "Please reset your password by <a href='{0}'>clicking here</a>.";

        // SQL Queries
        public const string SqlItemFormatRequired = "[{0}]";

        // Dates
        public const string LastLoginTimeDisplay = "dd.MM.yyyy HH:mm";
        public const string RequiredWebDateTimeFormat = "yyyy-MM-dd";
        public const string RequiredSqlDateTimeFormat = "yyyyMMdd";
        public const string SqlDateTimeFormatParsing = "dd/MM/yyyy";
        public const string PdfDateTimeFormatDisplay = "dd MMMM yyyy";
        public const string EmptyEndConnectionDisplay = "STILL VALID";

        // Folder names, mime types, formats, file names
        public const string ExcelFileExtension = ".xlsx";
        public const string PdfFileExtension = ".pdf";
        public const string ExcelStreamMimeType = "application/excel";
        public const string PdfStreamMimeType = "application/pdf";

        // Entities
        public const int IndexEntityIdInTable = 0;
        public const int IndexEntityNameInTable = 3;
        public const int IndexEntityHeadersInTable = 0;
        public const int RowNumberOfHeadersInTable = 1;
        public const int NumberOfAllowedColumnsInPdfView = 17;
        public const string DefaultAutocompleteSelectTerm = "Select...";
        public const string ContainerFundName = "FUND";
        public const string ContainerSubFundName = "SUB FUND";
        public const string UploadTypeProspectusDisplay = "Prospectus";
        public const string UploadTypeDocumentDisplay = "Document";
        public const string FundNameDisplay = "Fund";
        public const string SubFundNameDisplay = "Sub Fund";
        public const string ShareClassNameDisplay = "Share Class";

        // Toolbar Commands
        public const string CommandUpdateTable = "UPDATE";
        public const string CommandResetTable = "Reset";
        public const string CommandExtractExcel = "Excel";
        public const string CommandExtractPdf = "PDF";
    }
}
