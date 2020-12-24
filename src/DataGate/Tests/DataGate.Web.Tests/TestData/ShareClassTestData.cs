// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Tests.TestData
{
    using System.Collections.Generic;

    using DataGate.Data.Models.Entities;

    public class ShareClassTestData
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
    }
}
