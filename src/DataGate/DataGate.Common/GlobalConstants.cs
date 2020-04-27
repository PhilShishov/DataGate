using System;

namespace DataGate.Common
{
    public static class GlobalConstants
    {
        // Application Constants
        public const string SystemName = "DataGate";
        public const string DataGateFooterDisplay = "- Pharus Management Lux SA 16, Avenue de la Gare L- 1610 Luxembourg T. +352 28 55 69 - 1";

        // Keys
        public const string InfoKey = "info";
        public const string ErrorKey = "error";

        // Connection Strings
        public const string DataGateUsersConnection = "DataGateUsersConnection";
        public const string DataGatevFinaleConnection = "DataGate_vFinaleConnection";

        // User Roles
        public const string AdministratorRoleName = "Admin";
        public const string RiskRoleName = "Risk";
        public const string LegalRoleName = "Legal";
        public const string InvestmentRoleName = "Investement";
        public const string ComplianceRoleName = "Compliance";

        public const int MaxAdminCount = 3;
        public const string LastLoginTimeDisplay = "dd.MM.yyyy HH:mm";
        public const string DateTimeFormatDisplay = "yyyy-MM-dd";

        // Email
        public const string ConfirmEmailSubject = "Confirm your email";
        public const string EmailConfirmationMessage = "Please confirm your account by <a href='{0}'>clicking here</a>.";
        public const string ResetPasswordEmailSubject = "Reset Password";
        public const string PasswordResetMessage = "Please reset your password by <a href='{0}'>clicking here</a>.";

        // SQL Queries
        public const string SqlDateTimeFormatRequired = "yyyyMMdd";
        public const string SqlItemFormatRequired = "[{0}]";
    }
}
