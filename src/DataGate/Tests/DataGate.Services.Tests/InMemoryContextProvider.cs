// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests
{
    using DataGate.Data;
    using DataGate.Services.Tests.ClassFixtures;
    using DataGate.Services.Tests.Factories;

    using Xunit;

    public class InMemoryContextProvider : IClassFixture<MappingsProvider>
    {
        protected readonly UsersDbContext Context;

        public InMemoryContextProvider()
        {
            Context = ConnectionFactory.CreateContextForInMemory();
        }
    }
}
