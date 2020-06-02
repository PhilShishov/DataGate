namespace DataGate.Common
{
    public class ModelConstants
    {
        // User models constants
        public const string UserRoleDisplayName = "Role";

        // Login
        public const string UserLoginRememberMeDisplayName = "Remember me?";

        // Create User
        public const int UserUsernameMinLength = 3;
        public const int UserUsernameMaxLength = 20;
        public const int UserPasswordMinLength = 3;
        public const int UserPasswordMaxLength = 50;
        public const string UserConfirmPasswordDisplayName = "Confirm password";

        // Edit User
        public const string UserOldPasswordDisplayName = "Current password";
        public const string UserNewPasswordDisplayName = "New password";
    }
}
