// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Configuration
{
    using Microsoft.Extensions.DependencyInjection;

    using DataGate.Services.Data.Agreements;
    using DataGate.Services.Data.CountriesDist;
    using DataGate.Services.Data.Documents;
    using DataGate.Services.Data.Documents.Contracts;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Data.Funds;
    using DataGate.Services.Data.Recent;
    using DataGate.Services.Data.Reports;
    using DataGate.Services.Data.ShareClasses;
    using DataGate.Services.Data.Storage;
    using DataGate.Services.Data.Storage.Contracts;
    using DataGate.Services.Data.SubFunds;
    using DataGate.Services.Data.Timelines;
    using DataGate.Services.Data.TimeSeries;
    using DataGate.Services.Slug;
    using DataGate.Services.Data.Files;
    using DataGate.Services.Notifications;
    using DataGate.Services.Notifications.Contracts;
    using DataGate.Services.Data.Users;
    using DataGate.Web.Hubs;
    using DataGate.Web.Hubs.Contracts;
    using DataGate.Services.Data.Layouts;

    public static class BusinessLogicConfiguration
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            // Application services
            services.AddTransient<ISlugGenerator, SlugGenerator>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IEntitiesDocumentService, EntitiesDocumentService>();
            services.AddTransient<IEntityService, EntityService>();
            services.AddTransient<IEntityDetailsService, EntityDetailsService>();
            services.AddTransient<ITimelineService, TimelineService>();
            services.AddTransient<ITimeSeriesService, TimeSeriesService>();
            services.AddTransient<IAgreementsService, AgreementsService>();
            services.AddTransient<IReportsService, ReportsService>();
            services.AddTransient<ICountryDistService, CountryDistService>();

            //User Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRecentService, RecentService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<ILayoutService, LayoutService>();
            services.AddTransient<IHubNotificationHelper, HubNotificationHelper>();

            services.AddSingleton<IConnectionManager, ConnectionManager>();

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
