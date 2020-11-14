namespace DataGate.Common
{
    public static class GlobalConstants
    {
        // Meta data
        public const string AppName = "DataGate";
        public const string AuthorName = "Philip Shishov";
        public const string Keywords = 
            "ASP.NET Core, JavaScript, jQuery, " +
            "MSSQL, Git, GitHub, Fund Management Software, " +
            "Fund of Funds Software, Alternative Funds, Philip Shishov";

        // Application Constants
        public const string DataGateFullFooterDisplay = 
            "- Pharus Management Lux SA 16, Avenue de la Gare L-1610 Luxembourg";
        public const string FileSizeLimitConfiguration = "FileSizeLimit";
        public const int FileSizeLimit = 45 * 1024 * 1024;
        public const string DefaultCultureInfo = "en-US";
        public const string ItalianCultureInfo = "it-IT";
        public const int CultureCookieExpirationTimeInMonths = 5;
        public const int RedisCacheExpirationTimeInSeconds = 60 * 60 * 8;
        public const string AbortConnect = "abortConnect=false";

        // Tempdata Keys
        public const string SweetAlertKey = "sweetalert";
        public const string SweetAlertScript = "<script type='text/javascript'>swal('{0}', '{1}','{2}');</script>";
        public const string AlertifyKey = "alertify";
        public const string AlertifyScript = 
            "<script type='text/javascript'>alertify.set('notifier', 'position', 'top-left'); alertify.notify('{0}', '{1}', 5);</script>";

        // Connection Strings
        public const string DataGateUsersConnection = "DataGateUsersConnection";
        public const string DataGateAppConnection = "DataGateAppConnection";

        // Redis Cache
        public const string RedisCacheRecords = "CacheRecords_";

        // User Roles
        public const int MaxAdminCount = 3;
        public const string AdministratorRoleName = "Admin";
        public const string RiskRoleName = "Risk";
        public const string LegalRoleName = "Legal";
        public const string InvestmentRoleName = "Investment";
        public const string ComplianceRoleName = "Compliance";
        public const string GuestRoleName = "Guest";

        // Email
        public const string ConfirmEmailSubject = "Action required: Confirm your email";
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

        // Formats, mime types
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
        public const string UploadTypeProspectusDisplay = "Prospectus";
        public const string UploadTypeDocumentDisplay = "Document";

        // Toolbar Commands
        public const string CommandUpdateTable = "Update";
        public const string CommandResetTable = "Reset";
        public const string CommandExtractExcel = "Excel";
        public const string CommandExtractPdf = "PDF";
    }
}
