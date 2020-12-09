namespace DataGate.Data
{
    using System;

    using Microsoft.AspNetCore.Identity;

    public static class IdentityOptionsProvider
    {
        private const int MaxFailedAttemptsCount = 3;

        public static void GetIdentityOptions(IdentityOptions options)
        {
            var lockoutOptions = new LockoutOptions()
            {
                AllowedForNewUsers = true,
                DefaultLockoutTimeSpan = TimeSpan.FromDays(1),
                MaxFailedAccessAttempts = MaxFailedAttemptsCount
            };

            // TODO enable options for production
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 8;
            options.SignIn.RequireConfirmedEmail = true;

            options.Lockout = lockoutOptions;
        }
    }
}
