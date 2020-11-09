namespace DataGate.Web.Tests.TestData
{
    using DataGate.Data.Models.Entities;
    using System.Collections.Generic;

    public class ShareClassTestData
    {
        public static IEnumerable<TbHistoryShareClass> GenerateShareClasses() 
        {
            for (int i = 0; i < 5; i++)
            {
                yield return new TbHistoryShareClass
                {
                    ScId = i + 1,
                    ScOfficialShareClassName = $"pharus#{i}",
                };
            }
            for (int i = 5; i < 8; i++)
            {
                yield return new TbHistoryShareClass
                {
                    ScId = i + 1,
                    ScOfficialShareClassName = $"multi#{i}",
                };
            }
        }
    }
}
