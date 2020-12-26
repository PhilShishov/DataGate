// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.Notifications
{
    using System;

    using DataGate.Data.Models.Users.Enums;

    public class NotificationViewModel
    {
        public string Id { get; set; }

        public NotificationStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public string LinkUrl { get; set; }

        public string Content { get; set; }
    }
}