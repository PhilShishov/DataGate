// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.TestData
{
    using Xunit;

    public class ColumnDataGenerator : TheoryData<string[]>
    {
        public ColumnDataGenerator()
        {
            this.Add(new[] { "STATUS", "ID" });
        }
    }
}