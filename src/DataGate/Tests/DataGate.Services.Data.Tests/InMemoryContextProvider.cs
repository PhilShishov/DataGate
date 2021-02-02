// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests
{
    using DataGate.Data;
    using DataGate.Services.Data.Tests.ClassFixtures;
    using DataGate.Services.Data.Tests.Factories;

    using Xunit;

    public class InMemoryContextProvider : IClassFixture<MappingsProvider>
    {
        protected readonly ApplicationDbContext ApplicationContext;
        protected readonly UsersDbContext UsersContext;


        public InMemoryContextProvider()
        {
            ApplicationContext = ConnectionFactory.CreateApplicationContextForInMemory();
            UsersContext = ConnectionFactory.CreateUsersContextForInMemory();
        }
    }
}
