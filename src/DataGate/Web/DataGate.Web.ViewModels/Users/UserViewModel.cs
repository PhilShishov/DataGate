// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.Users
{
    using System;
    using System.Collections.Generic;

    public class UserViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public DateTimeOffset LastLogin { get; set; }

        public bool IsLogged { get; set; }
    }
}
