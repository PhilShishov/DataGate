// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Tests.ShareClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.ShareClasses;
    using DataGate.Services.Data.Tests.TestData;

    using Xunit;

    public class ShareClassServiceTests : InMemoryContextProvider
    {
        private readonly IEnumerable<TbPrimeShareClass> testData;
        private readonly ShareClassService service;

        public ShareClassServiceTests()
        {
            this.testData = ShareClassTestData.GenerateShareClasses();
            this.service = ShareClassTestData.CreateService(testData, base.context);
        }

        [Fact]
        public void DoesEntityExist_WithInvalidId_ShouldThrowException()
        {
            Action act = () => this.service.DoesExist(2000);

            Assert.Throws<EntityNotFoundException>(act);
        }

        [Fact]
        public void DoesEntityExist_WithValidId_ShouldReturnTrue()
        {
            Assert.True(this.service.DoesExist(5));
        }

        [Theory]
        [InlineData("LU00001")]
        [InlineData("LU00007")]
        public void IsIsin_WithValidSearch_ShouldReturnTrue(string searchTerm)
        {
            Assert.True(this.service.IsIsin(searchTerm));
        }

        [Theory]
        [InlineData("LU00015")]
        [InlineData("string")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("       ")]
        public void IsIsin_WithInvalidSearch_ShouldReturnFalse(string searchTerm)
        {
            Assert.False(this.service.IsIsin(searchTerm));
        }

        [Fact]
        public void ByIsin_WithValidSearch_ShouldReturnExistingShareClassId()
        {
            var expected = 1;
            var actual = this.service.ByIsin("LU00001");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ByDate_ShouldReturnOrderedShareClassList()
        {
            var expected = this.testData
                .OrderByDescending(sc => sc.ScInitialDate)
                .Take(10)
                .ToList();

            var actual = this.service
                .ByDate()
                .ToList();

            Assert.Equal(expected.Count(), actual.Count());

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].ScId, actual[i].ScId);
                Assert.Equal(expected[i].ScOfficialShareClassName, actual[i].ScOfficialShareClassName);
            }
        }
    }
}
