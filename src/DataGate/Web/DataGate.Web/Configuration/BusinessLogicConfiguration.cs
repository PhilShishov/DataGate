namespace DataGate.Web.Configuration
{
    using DataGate.Services.Data;
    using DataGate.Services.Data.Documents;
    using DataGate.Services.Data.Documents.Contracts;
    using DataGate.Services.Data.Files.Contracts;
    using DataGate.Services.Data.Funds;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Services.Data.ShareClasses;
    using DataGate.Services.Data.ShareClasses.Contracts;
    using DataGate.Services.Data.Storage;
    using DataGate.Services.Data.Storage.Contracts;
    using DataGate.Services.Data.SubFunds;
    using DataGate.Services.Data.SubFunds.Contracts;
    using DataGate.Services.Data.Timelines;
    using DataGate.Services.Data.Timelines.Contracts;
    using DataGate.Services.Messaging;
    using DataGate.Services.SqlClient;
    using DataGate.Services.SqlClient.Contracts;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class BusinessLogicConfiguration
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Application services
            services.AddTransient<IEmailSender>(x => new SendGridEmailSender(configuration.GetValue<string>("SendGrid:ApiKey")));
            services.AddTransient<ISettingsService, SettingsService>();

            services.AddTransient<ISqlQueryManager, SqlQueryManager>();
            services.AddTransient<IFileSystemService, FileSystemService>();

            // Funds
            services.AddTransient<IFundService, FundService>();
            services.AddTransient<IFundSubFundsService, FundSubFundsService>();
            services.AddTransient<IFundDetailsService, FundDetailsService>();
            services.AddTransient<IFundDocumentService, FundDocumentService>();
            services.AddTransient<IFundTimelineService, FundTimelineService>();
            services.AddTransient<IFundsSelectListService, FundsSelectListService>();
            services.AddTransient<IFundStorageService, FundStorageService>();

            // Sub Funds
            services.AddTransient<ISubFundService, SubFundService>();
            services.AddTransient<ISubFundShareClassesService, SubFundShareClassesService>();
            services.AddTransient<ISubFundDetailsService, SubFundDetailsService>();

            // Share Classes
            services.AddTransient<IShareClassService, ShareClassService>();
            services.AddTransient<IShareClassDetailsService, ShareClassDetailsService>();

            return services;
        }
    }
}
