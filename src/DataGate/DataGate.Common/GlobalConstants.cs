namespace DataGate.Common
{
    public static class GlobalConstants
    {
        // Application Constants
        public const string SystemName = "DataGate";
        public const string DataGateFooterDisplay = "- Pharus Management Lux SA 16, Avenue de la Gare L- 1610 Luxembourg T. +352 28 55 69 - 1";

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
    }
}
