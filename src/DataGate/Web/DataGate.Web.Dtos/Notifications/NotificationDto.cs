// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Dtos.Notifications
{
    using System.Security.Claims;

    public class NotificationDto
    {
        public string Arg { get; set; }

        public ClaimsPrincipal User { get; set; }

        public string Message { get; set; }

        public string Link { get; set; }
    }
}