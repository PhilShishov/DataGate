// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.Users
{
    using System.Collections.Generic;

    using DataGate.Data.Models.Entities;
    using DataGate.Data.Models.Users;

    public class UserPanelViewModel
    {
        public IEnumerable<TbPrimeShareClass> ShareClasses { get; set; }

        public IEnumerable<RecentlyViewed> RecentlyViewed { get; set; }
    }
}
