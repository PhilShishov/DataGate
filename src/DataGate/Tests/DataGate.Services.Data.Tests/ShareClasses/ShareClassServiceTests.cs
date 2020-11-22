namespace DataGate.Services.Data.Tests.ShareClasses
{
    using System;
    using System.Threading.Tasks;

    using Xunit;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Models.Entities;
    using System.Collections.Generic;
    using DataGate.Services.Data.Tests.TestData;
    using DataGate.Services.Data.ShareClasses;

    public class ShareClassServiceTests : TransientDbContextProvider
    {
        private readonly IEnumerable<TbPrimeShareClass> testData;
        private readonly ShareClassService service;

        public ShareClassServiceTests(IShareClassService service)
        {
            this.testData = ShareClassTestData.GenerateShareClasses();
            this.service = ShareClassTestData.CreateShareClassService(testData, base.context);
        }

        [Fact]
        public void DoesEntityExist_WithInvalidId_ShouldThrowException()
        {
            Action act = () => this.service.DoesEntityExist(20);

            Assert.Throws<EntityNotFoundException>(act);
        }

        [Fact]
        public void DoesEntityExist_WithValidId_ShouldReturnTrue()
        {
           Assert.True(this.service.DoesEntityExist(5));
        }

    }
}
