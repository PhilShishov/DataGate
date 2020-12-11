namespace DataGate.Services.Data.Tests.TestData
{
    using System;
    using System.Collections.Generic;

    using DataGate.Data;
    using DataGate.Data.Common.Repositories.AppContext;
    using DataGate.Data.Models.Entities;
    using DataGate.Data.Repositories.AppContext;
    using DataGate.Services.Data.ShareClasses;

    public static class ShareClassTestData
    {
        public static IEnumerable<TbPrimeShareClass> GenerateShareClasses() 
        {
            for (int i = 1; i < 10; i++)
            {
                yield return new TbPrimeShareClass
                {
                    ScId = i,
                    ScOfficialShareClassName = $"pharus#{i}",
                    ScIsinCode = $"LU0000{i}",
                    ScInitialDate = new DateTime(2020, 01, i),
                };
            }
            for (int i = 10; i <= 20; i++)
            {
                yield return new TbPrimeShareClass
                {
                    ScId = i,
                    ScOfficialShareClassName = $"multi#{i}",
                    ScIsinCode = $"LU0000{i}",
                    ScInitialDate = new DateTime(2020, 01, i),

                };
            }
        }

        public static ShareClassService CreateShareClassService(
            IEnumerable<TbPrimeShareClass> testData,                                                                     
            ApplicationDbContext context)
        {
            context.TbPrimeShareClass.AddRangeAsync(testData);
            context.SaveChangesAsync();
            IAppRepository<TbPrimeShareClass> repository = new EfAppRepository<TbPrimeShareClass>(context);
            var service = new ShareClassService(repository);
            return service;
        }
    }
}
