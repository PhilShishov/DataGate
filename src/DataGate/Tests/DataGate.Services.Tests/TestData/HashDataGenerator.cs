// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.TestData
{
    using System;
    using Xunit;

    public class HashDataGenerator : TheoryData<string, object>
    {
        public HashDataGenerator()
        {
            this.Add("link", "https://github.com");
            this.Add("numbers", 88);
            this.Add("time", DateTime.Now.Ticks);
        }
    }
}
