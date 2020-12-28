// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests
{
    using System.Collections.Generic;

    using Xunit.Abstractions;

    public static class TestsHelper
    {
        public static void PrintTableOutput(ITestOutputHelper output, string functionName, List<string[]> result)
        {
            output.WriteLine(functionName);

            foreach (var line in result)
            {
                output.WriteLine(string.Join('|', line));
            }
        }
    }
}
