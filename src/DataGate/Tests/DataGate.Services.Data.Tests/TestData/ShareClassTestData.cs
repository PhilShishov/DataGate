namespace DataGate.Services.Data.Tests.TestData
{
    using System.Collections.Generic;

    using DataGate.Data;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Data.Repositories;
    using DataGate.Services.Data.ShareClasses;

    public static class ShareClassTestData
    {
        public static IEnumerable<TbPrimeShareClass> GenerateShareClasses() 
        {
            for (int i = 0; i < 5; i++)
            {
                yield return new TbPrimeShareClass
                {
                    ScId = i + 1,
                    ScOfficialShareClassName = $"pharus#{i}",
                    ScIsinCode = $"LU0000{i}",
                };
            }
            for (int i = 5; i < 8; i++)
            {
                yield return new TbPrimeShareClass
                {
                    ScId = i + 1,
                    ScOfficialShareClassName = $"multi#{i}",
                    ScIsinCode = $"LU0000{i}",
                };
            }
        }

        public static ShareClassService CreateShareClassService(
            IEnumerable<TbPrimeShareClass> testData,                                                                     
            ApplicationDbContext context)
        {
            context.TbPrimeShareClass.AddRangeAsync(testData);
            context.SaveChangesAsync();
            IRepository<TbPrimeShareClass> repository = new EfRepository<TbPrimeShareClass>(context);
            var service = new ShareClassService(repository);
            return service;
        }
    }
}
