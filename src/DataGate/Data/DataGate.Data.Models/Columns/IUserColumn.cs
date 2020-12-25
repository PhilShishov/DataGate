// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Data.Models.Columns
{
    using DataGate.Data.Models.Users;

    public interface IUserColumn
    {
        string Id { get; set; }

        string Name { get; set; }

        string UserId { get; set; }

        ApplicationUser User { get; set; }
    }
}
