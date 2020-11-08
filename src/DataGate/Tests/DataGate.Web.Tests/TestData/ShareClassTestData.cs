namespace DataGate.Web.Tests.TestData
{
    using DataGate.Data.Models.Entities;
    using System.Collections.Generic;

    public class ShareClassTestData
    {
        public static IEnumerable<TbHistoryShareClass> GenerateShareClasses() 
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new TbHistoryShareClass
                {
                    ScId = i + 1,
                    ScOfficialShareClassName = $"resource#{i}",
                };
            }
        }
    }
}
