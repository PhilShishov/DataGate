// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Tests.TestData
{
    using System.Collections.Generic;

    public class HashTestData
    {
        public static IList<KeyValuePair<string, int>> GenerateKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, int>>();
            for (int i = 1; i <= 10; i++)
            {
                list.Add(new KeyValuePair<string, int>(i.ToString(), i));
            }

            return list;
        }
    }
}
