// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.Collections
{
    using DataGate.Common;
    using DataGate.Services.Data.Tests.ClassFixtures;

    using Xunit;

    [CollectionDefinition(GlobalConstants.SqlServerCollection)]
    public class SqlServerCollection : ICollectionFixture<SqlServerFixture>
    {
    }
}