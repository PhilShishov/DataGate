namespace DataGate.Web.Configuration
{
    using DataGate.Services.Data.Agreements;
    using DataGate.Services.Data.Agreements.Contracts;
    using DataGate.Services.Data.Documents;
    using DataGate.Services.Data.Documents.Contracts;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.Files.Contracts;
    using DataGate.Services.Data.Funds;
    using DataGate.Services.Data.Reports;
    using DataGate.Services.Data.ShareClasses;
    using DataGate.Services.Data.Storage;
    using DataGate.Services.Data.Storage.Contracts;
    using DataGate.Services.Data.SubFunds;
    using DataGate.Services.Data.Timelines;
    using DataGate.Services.Data.TimeSeries;
    using DataGate.Services.Slug;
    using Microsoft.Extensions.DependencyInjection;

    public static class BusinessLogicConfiguration
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            // Application services
            services.AddTransient<ISlugGenerator, SlugGenerator>();

            services.AddTransient<IFileSystemService, FileService>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IEntitiesDocumentService, EntitiesDocumentService>();
            services.AddTransient<IEntityService, EntityService>();
            services.AddTransient<IEntityDetailsService, EntityDetailsService>();
            services.AddTransient<ITimelineService, TimelineService>();
            services.AddTransient<ITimeSeriesService, TimeSeriesService>();
            services.AddTransient<IAgreementsService, AgreementsService>();
            services.AddTransient<IReportsService, ReportsService>();

            // Funds
            services.AddTransient<IFundService, FundService>();
            services.AddTransient<IFundSelectListService, FundSelectListService>();
            services.AddTransient<IFundStorageService, FundStorageService>();

            // Sub Funds
            services.AddTransient<ISubFundService, SubFundService>();
            services.AddTransient<ISubFundStorageService, SubFundStorageService>();

            // Share Classes
            services.AddTransient<IShareClassService, ShareClassService>();
            services.AddTransient<IShareClassStorageService, ShareClassStorageService>();

            return services;
        }
    }
}
