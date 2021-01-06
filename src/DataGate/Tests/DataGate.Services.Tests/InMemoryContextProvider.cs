// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests
{
    using DataGate.Data;
    using DataGate.Data.Models.Users;
    using DataGate.Services.Tests.ClassFixtures;
    using DataGate.Services.Tests.Factories;

    using Microsoft.Extensions.DependencyInjection;

    using Xunit;

    public class InMemoryContextProvider : IClassFixture<MappingsProvider>
    {
        protected readonly UsersDbContext Context;
        protected readonly ServiceProvider ServiceProvider;

        public InMemoryContextProvider()
        {
            Context = ConnectionFactory.CreateContextForInMemory();
        }
    }
}
