namespace DataGate.Data
{
    using Microsoft.AspNetCore.Identity;

    public static class IdentityOptionsProvider
    {
        public static void GetIdentityOptions(IdentityOptions options)
        {
            // TODO enable options for production
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 8;
            options.SignIn.RequireConfirmedEmail = true;
        }
    }
}
