// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.Notifications
{
    using System;

    using AutoMapper;

    using DataGate.Data.Models.Users;
    using DataGate.Services.Mapping;
    using DataGate.Web.Infrastructure.Extensions;

    public class NotificationViewModel : IMapFrom<UserNotification>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnFormatted => DateTimeExtensions.TimeAgo(this.CreatedOn);

        public string LinkUrl { get; set; }

        public string Content { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<UserNotification, NotificationViewModel>()
                .ForMember(vm => vm.Status, action => action.MapFrom(model => model.Status.ToString("g")));
        }
    }
}